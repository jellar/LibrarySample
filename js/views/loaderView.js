export default class LoaderView {
    renderLoader = parent => {
        const loader = `
        <div class="loader">
            <svg>
                <use href="img/icons.svg#icon-cw"></use>
            </svg>
        </div>
    `;
        parent.insertAdjacentHTML('afterbegin', loader);
    };

    clearLoader = () => {
        const loader = document.querySelector(".loader");
        if (loader) loader.parentElement.removeChild(loader);
    };
}
