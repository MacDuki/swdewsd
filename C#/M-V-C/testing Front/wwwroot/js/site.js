window.addEventListener('load', syncTableHeader);

function syncTableHeader() {
    const table = document.getElementById('myTable');
    const thead = table.querySelector('thead');
    const tbody = table.querySelector('tbody');
    const headerCells = thead.querySelectorAll('th');
    const bodyCells = tbody.querySelector('tr').querySelectorAll('td');

    headerCells.forEach((headerCell, index) => {
        headerCell.style.width = `${bodyCells[index].offsetWidth}px`;
    });
}



