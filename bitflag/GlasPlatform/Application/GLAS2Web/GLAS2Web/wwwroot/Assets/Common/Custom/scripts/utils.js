function getListActions(actions) {
    var r = '<div class="text-center">';

    var items = [];
    $.each(actions, function (i, e) { items.push('<a href="' + e.action + '">' + e.text + '</a>'); });

    r += items.join(' | ');

    r += '</div>';

    return r;
}

var typingTimer = {};
var doneTypingIntervalBase = 1000;

function doneTyping(searchVal, table) {
    $(table).DataTable().search(searchVal).draw();
}

function initSearchDataTable() {
    $('input[data-toggle="search-datatable"]').off('keyup');
    $('input[data-toggle="search-datatable"]').on('keyup', function () {
        console.log('asd');

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
$(document).ready(initSearchDataTable);

function validateInputs(parent) {
    if (isNullOrWhiteSpace(parent)) $('.text-danger').remove();
    else $(parent + ' .text-danger').remove();

    var hasError = false;
    var elements = $('.required + input:visible, .required + select:visible, .required + textarea:visible, input.required, select.required:visible, textarea.required:visible').not(':disabled').map(function (i, e) { return '[name="' + $(e).attr('name') + '"]'; });

    if (!isNullOrWhiteSpace(parent))
        elements = $(parent).find('.required + input:visible, .required + select:visible, .required + textarea:visible, input.required:visible, select.required:visible, textarea.required:visible').not(':disabled').map(function (i, e) { return '[name="' + $(e).attr('name') + '"]'; });

    elements = $.distinct(elements);

    $.each(elements, function (i, e) {
        var input = $(e);
        var area = ((input.data('target') != null) ? $(input.data('target')) : input);

        if ($($(input)[0]).attr('type') == 'radio' && isNullOrWhiteSpace($(input).closest(':checked').val())) {
            var message = isNullOrWhiteSpace($(input).data('error-message')) ? 'Este campo deve ser preenchido.' : $(input).data('error-message');

            area.after($('<small>', { class: "text-danger font-weight-bold", style: 'font-size: 11px;' }).append(message));
            hasError = true;
        }
        else if (isNullOrWhiteSpace(input.val())) {
            var message = isNullOrWhiteSpace($(input).data('error-message')) ? 'Este campo deve ser preenchido.' : $(input).data('error-message');
            area.after($('<small>', { class: "text-danger font-weight-bold", style: 'font-size: 11px;' }).append(message));
            hasError = true;
        }
    });

    if (hasError) {
        $("html, body").animate({ scrollTop: 0 }, "slow");
        bootbox.alert('Há erro(s) no formulário, verifique os campos e tente novamente.');
    }

    return !hasError;
}

$.extend({
    distinct: function (anArray) {
        var result = [];
        $.each(anArray, function (i, v) {
            if ($.inArray(v, result) == -1) result.push(v);
        });
        return result;
    }
});

function isNullOrWhiteSpace(val) {
    if (val === null || val === undefined) return true;
    val = val.toString();

    val = val.replace(/\s+/g, '');
    return val === '';
}