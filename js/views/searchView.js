class SearchView {
    _parentEl = document.querySelector('.search');
    _inputEl = document.querySelector('.search__field')
    getQuery() {
        const query = this._parentEl.querySelector('.search__field').value;
        //this._clearInput();
        return query;
    }

    _clearInput() {
        this._parentEl.querySelector('.search__field').value = '';
    }

    addHandlerSearch(handler) {
        this._parentEl.addEventListener('submit', function (e) {
            e.preventDefault();
            handler();
        });
    }

    addHandlerKeyDown(handler) {
        this._inputEl.addEventListener('keyup', function (e) {           
            handler();
        });
    }
}

export default new SearchView();

