export const state = {
    books: [],
    selectedBookId:'',
    selectedBookTitle: '',
    search: {
        query: '',
        results: [],
    }
};


export const loadBooks = async function () {
    try {
        const res = await fetch('http://localhost:49265/api/books');
        const data = await res.json();
        console.log(data);
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
        const res = await fetch('http://localhost:53471/api/books/'+ bookId);
        const data = await res.json();
        console.log(data);
        state.search.results = data.map(w=>{
            return {
                word: w.word,
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
        const res = await fetch(`http://localhost:53471/api/books/${bookId}?query=${query}`);
        const data = await res.json();
        console.log(data);
        state.search.results = data.map(w=>{
            return {
                word: w.word,
                count: w.count
            }
        });
    }
    catch (err) {
        console.error(err);
        throw err;
    }
}
   