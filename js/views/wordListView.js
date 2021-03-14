
class WordListView {  
    _tableEl = document.getElementById('book-word-details');  
    
    render(data, title) {  
        const $spanTitle = document.getElementById('spanTitle');
        $spanTitle.innerText = '';
        $spanTitle.innerText = title;
        
        this._tableEl.innerHTML = '';

        for (let i = 0, len = data.length; i < len; i++) {
            let $row = document.createElement('tr');
            let $tdWord = document.createElement('td');
            let $tdCount = document.createElement('td');

            $tdWord.innerText = data[i]['word'];
            $tdCount.innerText = data[i]['count'];
            $row.append($tdWord);
            $row.append($tdCount)
            this._tableEl.append($row);
        }        
    }   
      
}

export default new WordListView();