function IsNullOrWhiteSpace(input) {
    if (input == null) return true;
    if (input.length == 0) return true;
    return !input || !input.trim();
}

function fieldHasValue(sel) {
    return !IsNullOrWhiteSpace($(sel).val());
}

function ReplaceDots(value) {
    if (value.indexOf('.') != -1) {
        value = value.replace('.', ',');
    }
    return value;
}

function MoneyToFloat(value) {
    if (value == null || value == '') return 0;
    if (value.indexOf('.') != -1)
        value = value.replace(/\./g, '');
    if (value.indexOf(',') != -1)
        value = value.replace(',', '.');

    return value == null ? 0 : parseFloat(value);
}

function getListActionsLink(actions) {
    var r = '<div class="dropdown"><ul class="nav justify-content-center p-0"><li class="nav-item dropdown"><a data-boundary="" class="nav-link dropdown-toggle p-0" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false"><i class="fas fa-bars"></i></a><div class="dropdown-menu">';



    $.each(actions, function (i, e) {
        if (e.isActive == true) {
            r += '<a style="font-family: Roboto, sans-serif;" href="' + e.link + '" class="dropdown-item">' + e.text + '</a>';
        } else {
            r += '<span style="font-family: Roboto, sans-serif;" class="dropdown-item disabled">' + e.text + '</span>';
        }

    });
    r += '</div></li></ul></div>';

    return r;
}


$.extend(true, $.fn.dataTable.defaults, {
    "iDisplayLength": 10,
    'language': {
        "sEmptyTable": "Nenhum registro encontrado",
        "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
        "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
        "sInfoFiltered": "(Filtrados de _MAX_ registros)",
        "sInfoPostFix": "",
        "sInfoThousands": ".",
        "sLengthMenu": "_MENU_ resultados por página",
        "sLoadingRecords": "Carregando...",
        "sProcessing": "Processando...",
        "sZeroRecords": "Nenhum registro encontrado",
        "sSearch": "Pesquisar",
        "oPaginate": {
            "sNext": "Próximo",
            "sPrevious": "Anterior",
            "sFirst": "Primeiro",
            "sLast": "Último"
        },
        "oAria": {
            "sSortAscending": ": Ordenar colunas de forma ascendente",
            "sSortDescending": ": Ordenar colunas de forma descendente"
        }
    }
});

function _MaskData() {
    $('.quota').mask('#,0', { reverse: true });
    $('._date').mask('00/00/0000');
    $('.date').mask('00/00/0000');
    $('.date').datepicker({ format: 'dd/mm/yyyy', language: 'pt-BR', autoclose: true });
    $('.time').mask('00:00:00');
    $('.date-time').mask('00/00/0000 00:00:00');
    $('.monthYear').mask('00/0000', { clearIfNotMatch: true });
    $('.monthYear').datepicker({ format: 'mm/yyyy', startView: "year", minViewMode: "months", language: 'pt-BR', autoclose: true });
    $('.cep').mask('00000-000');
    $('.mobile').mask('(00) #0000-0000');
    $('.phone').mask('(00) 0000-0000');
    $('.percent5').mask('##0,00000', { reverse: true });
    $('.percent2').mask('##0,00', { reverse: true });
    $('.cnpj').mask('00.000.000/0000-00', { reverse: true, clearIfNotMatch: true });
    $('.cpf').mask('000.000.000-00', { reverse: true, clearIfNotMatch: true });
    $('._cpf').mask('#000.000.000-00', { reverse: true, clearIfNotMatch: true });
    $('.money').mask('#.##0,00', { reverse: true });
    $('.placa').mask('SSS-0000');
    $('.fipe').mask('000000-0');
    $('.renavam').mask('00000000-0');
    $('.year').mask('0000');
    $('.rg').mask('00.000.000-00');
    $('.number').mask('#');
}
$(function () {
    _MaskData();

    //$('.dataTables_length select').select2({ minimumResultsForSearch: Infinity });
});

function toPtBRDate(dateStr) {
    if (IsNullOrWhiteSpace(dateStr)) return '';

    return moment(dateStr).format('DD/MM/YYYY');
}

function toPtBRDateTime(dateStr) {
    if (IsNullOrWhiteSpace(dateStr)) return '';

    return moment(dateStr).format('DD/MM/YYYY HH:mm');
}


function fromPtBRDate(dateStr) {
    if (IsNullOrWhiteSpace(dateStr)) return null;

    return moment(dateStr, 'DD/MM/YYYY')._d;
}

var typingTimer = {};
var doneTypingIntervalBase = 1000;

function doneTyping(searchVal, table) {
    $(table).DataTable().search(searchVal).draw();
}

function initializeDatatableSearch() {
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

$(document).ready(function () {
    $('#_CertificateManageRealEstateId').change(function () {
        clearTimeout(doneTypingIntervalBase);
        let value = $(this).val();
        var table = $(this).dataTable('target');
        var timeout = $(this).data('timeout');

        typingTimer[table] = setTimeout(function () { doneTyping(value, table); }, timeout ?? doneTypingIntervalBase);
    });
    initializeDatatableSearch();
    Globalize.culture("pt-BR");
});

function validateInputs(parent) {
    if (IsNullOrWhiteSpace(parent)) $('.text-danger').remove();
    else $('#' + parent + ' .text-danger').remove();

    var hasError = false;
    var elements = $('.required + input:visible, .required + select:visible, .required + textarea:visible, .required + .input-group > input:visible, .required + .input-group > select:visible, .required + .input-group > textarea:visible, input.required, select.required:visible, textarea.required:visible'); //, .required + select:visible + .select2-container

    if (!IsNullOrWhiteSpace(parent))
        elements = $('#' + parent).find('.required + input:visible, .required + select:visible, .required + textarea:visible, .required + .input-group > input:visible, .required + .input-group > select:visible, .required + .input-group > textarea:visible, input.required:visible, select.required:visible, textarea.required:visible'); //, .required + select:visible + .select2-container

    //elements = elements.toArray().filter(function (val) {
    //    return $('.required + select:visible + .select2-container').prev('select').toArray().indexOf(val) == -1;// remove selects quando é utilizado select2 (select2 é um span e não um select)
    //});

    $.each(elements, function (i, e) {
        var input = $(e);
        var area = input.closest('.input-group');
        area = area.length == 0 ? ((input.data('target') != null) ? $(input.data('target')) : input) : area;

        if (IsNullOrWhiteSpace(input.val())) {
            var message = IsNullOrWhiteSpace($(input).data('error-message')) ? 'Este campo deve ser preenchido.' : $(input).data('error-message');

            area.after($('<div>', { class: "text-danger", style: 'font-size: 11px;' }).append(message));
            hasError = true;
        }
    });

    return !hasError;
}

function initializeCopyToClipboard() {
    $('[data-copy-to-clipboard]').off('click');

    $('[data-copy-to-clipboard]').click(function () {
        var input = $('<input>', { value: $(this).data('text') });

        $('body').append(input);

        $(input).select();

        document.execCommand("copy");

        alert('O link foi copiado.');
        $(input).remove();
    });
}

$(document).ready(initializeCopyToClipboard);