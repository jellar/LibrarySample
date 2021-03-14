import BookListView from "./views/bookListView.js";
import * as model from './model.js';
import SearchView from "./views/searchView.js";
import WordListView from "./views/wordListView.js";
import LoaderView from "./views/loaderView.js";
class App
{
    bookListView;
    searchView;
    wordListView;
    loaderView;
	constructor() {
		// setup
        this.bookListView = new BookListView()
        this.searchView = new SearchView();
        this.wordListView = new WordListView();
        this.loaderView = new LoaderView();
    }

    async go() {
        // retrieve and display the list of books
        await model.loadBooks();
        this.bookListView.render(model.state.books);

        this.bookListView.addHandlerClick(this.selectedBook);
        this.searchView.addHandlerSearch(this.controlSearchResults)
        this.searchView.addHandlerKeyDown(this.controlSearchResults)
	}

    controlSearchResults = async () => {
        const query = this.searchView.getQuery();
        if(query && query.length > 2){
            this.loaderView.renderLoader(document.querySelector('#results'));
            await model.searchWordsStartsWith(query, model.state.selectedBookId);
            const header = `Words in "${model.state.selectedBookTitle}" starting with "${query}"`
            this.loaderView.clearLoader();
            this.wordListView.render(model.state.search.results, header)
        }       
    };

    selectedBook = async (goToBook, title) => {
        this.searchView._clearInput();
        this.searchView.enabledFields();
        this.loaderView.renderLoader(document.querySelector('#results'));
        await model.getCommonWords(goToBook, title);
        this.loaderView.clearLoader();
        const header = `Most Common words in "${title}"`
        this.wordListView.render(model.state.search.results, header);
    };
}
new App().go();