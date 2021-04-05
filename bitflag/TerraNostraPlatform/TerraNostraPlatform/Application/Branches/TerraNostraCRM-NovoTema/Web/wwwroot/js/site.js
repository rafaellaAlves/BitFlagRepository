function IsNullOrWhiteSpace(input) {
    if (input == null) return true;
    if (input.length == 0) return true;
    return !input || !input.trim();
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
            "sNext": '<i class="simple-icon-arrow-right"></i>',
            "sPrevious": '<i class="simple-icon-arrow-left"></i>',
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
    $('.monthYear').mask('00/0000');
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
    $('.money-text').unmask();
    $('.money-text').mask('#.##0,00');
    $('.placa').mask('SSS-0000');
    $('.fipe').mask('000000-0');
    $('.renavam').mask('00000000-0');
    $('.year').mask('0000');
    $('.rg').mask('00.000.000-00');
    $('.number').mask('#');
    $('.number2').mask('00');
}

function getTotalDaysInMonth(year, month) {
    return Math.round(((new Date(year, month)) - (new Date(year, month - 1))) / 86400000);
}

function disabledFields(parent) {
    if (!IsNullOrWhiteSpace(parent)) {
        $('#' + parent + ' input').attr('disabled', 'disabled');
        $('#' + parent + ' select').attr('disabled', 'disabled');
        $('#' + parent + ' textarea').attr('disabled', 'disabled');
    } else {
        $('input').attr('disabled', 'disabled');
        $('select').attr('disabled', 'disabled');
        $('textarea').attr('disabled', 'disabled');

    }
}

$(function () {
    _MaskData();
});