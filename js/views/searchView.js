export default class SearchView {
    _parentEl = document.querySelector('.search');
    _inputEl = document.querySelector('.search__field');
    _buttonEl = document.querySelector('.search__btn');
    getQuery() {
        const query = this._parentEl.querySelector('.search__field').value;
        //this._clearInput();
        return query;
    }

    _clearInput() {
        this._parentEl.querySelector('.search__field').value = '';
    }
    enabledFields(){
        this._inputEl.removeAttribute('disabled');
        this._buttonEl.removeAttribute('disabled');
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


