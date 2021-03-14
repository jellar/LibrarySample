export default class BookListView {
    _data;
    _listEl = document.querySelector('#book-list');   
   
    render(data) {
        this._data = data;
       
        const $bookListUI = document.getElementById('book-list');
        // clear HTML from the DOM 
        this._listEl.innerHTML = '';

        for (let i = 0, len = this._data.length; i < len; i++) {
            let $li = document.createElement('li');
            $li.setAttribute('class', 'book-list-item');
            $li.setAttribute('data-index', this._data[i]['id']);
            $li.setAttribute('data-goto', this._data[i]['id']);
            $li.setAttribute('data-title', this._data[i]['title']);
            $li.innerHTML = this._data[i]['title'];                   
            this._listEl.append($li);
        }
    }

    addHandlerClick(handler) {    
        
        this._listEl.addEventListener('click', function (e) {
            const elems = document.querySelectorAll(".book-list-item");
            [].forEach.call(elems, function(el) {
                el.classList.remove("selected");
            });
            
            e = e || window.event;
            const li =  e.target || e.srcElement            
            if (!li) return;
            
            li.classList.add('selected');
            const goToBook = +li.dataset.goto;
            const title = li.dataset.title;
            handler(goToBook, title);
        });
    }   
    
}
