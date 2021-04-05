function searchDatatableInitialize() {
    var typingTimer = {};
    var doneTypingIntervalBase = 1000;

    function doneTyping(searchVal, table) {
        $(table).DataTable().search(searchVal).draw();
    }

    $('input[data-toggle="search-datatable"]').on('keyup', function () {
        clearTimeout(doneTypingIntervalBase);

        var table = $(this).data('target');
        var searchVal = $(this).val();
        var timeout = $(this).data('timeout');

        typingTimer[table] = setTimeout(function () { doneTyping(searchVal, table); }, timeout ?? doneTypingIntervalBase);

    });
    $('input[data-toggle="search-datatable"]').on('keydown', function () {
        clearTimeout(typingTimer[$(this).data('target')]);
    });
}

$(document).ready(searchDatatableInitialize);