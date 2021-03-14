export const state = {
    books: [],
    selectedBookId:'',
    selectedBookTitle: '',
    search: {
        query: '',
        results: [],
    }
};

function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}
export const loadBooks = async function () {
    try {
        const res = await fetch(`${getBaseUrl()}api/books`);
        const data = await res.json();        
        state.books = data.map(b=>{
            return {
                id: b.id,
                title: b.title
            }
        });
    } catch (err) {
        console.error(err);
        throw err;
    }
};

export const getCommonWords = async function(bookId, title) {
    try{
        state.selectedBookId = bookId;
        state.selectedBookTitle = title;
        const res = await fetch(`${getBaseUrl()}api/books/${bookId}`);
        const data = await res.json();       
        state.search.results = data.map(w=>{
            return {
                word: w.wordText,
                count: w.count
            }
        });
    }
    catch (err) {
        console.error(err);
        throw err;
    }
}

export const searchWordsStartsWith = async function(query, bookId)  {
    try{
        state.search.query = query;
        const res = await fetch(`${getBaseUrl()}api/books/${bookId}?query=${query}`);
        const data = await res.json();        
        state.search.results = data.map(w=>{
            return {
                word: w.wordText,
                count: w.count
            }
        });
    }
    catch (err) {
        console.error(err);
        throw err;
    }
}
   