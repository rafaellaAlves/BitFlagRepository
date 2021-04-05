function _MaskData() {
    $('.date').mask('00/00/0000');
    $('.date').datepicker({ format: 'dd/mm/yyyy', language: 'pt-BR', autoclose: true });
    $('.time').mask('00:00:00');
    $('.date-time').mask('00/00/0000 00:00:00');
    $('.cep').mask('00000-000');
    $('.mobile').mask('(00) #0000-0000', { clearIfNotMatch: true });
    $('.phone').mask('(00) 0000-0000', { clearIfNotMatch: true });
    $('.percent').mask('##0,00%', { reverse: true });
    $('._percent').mask('##0,00', { reverse: true });
    $('.cnpj').mask('00.000.000/0000-00', { reverse: true, clearIfNotMatch: true });
    $('.cpf').mask('000.000.000-00', { reverse: true, clearIfNotMatch: true });
    $('._cpf').mask('#000.000.000-00', { reverse: true, clearIfNotMatch: true });
    $('.money').mask('#.##0,00', { reverse: true });
    $('.placa').mask('SSS-0000');
    $('.consultor').mask('SSS0000');
    $('.fipe').mask('000000-0');
    $('.renavam').mask('00000000-0');
    $('.year').mask('0000');
    $('.rg').mask('00.000.000-00');
    $('.number').mask('#');
    $('.weight-height').mask('#00.00', { reverse: true });
}
$(function () {
    _MaskData();
});

function toDate(dateStr) {
    var parts = dateStr.split("/");
    return new Date(parts[2], parts[1] - 1, parts[0]);
}

function AmericanDate(dateStr) {
    var parts = dateStr.split("/");
    return  parts[1] + '/' + parts[0] + '/' + parts[2];
}

function getAge(dateString) {
    var today = new Date();
    var birthDate = toDate(dateString);
    var age = today.getFullYear() - birthDate.getFullYear();
    var m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
        age--;
    }
    return age;
}

function IsNullOrWhiteSpace(input) {
    if (input == null) return true;
    if (input.length == 0) return true;
    return !input || !input.trim();
}

function LimparCamposEndereco() {
    $("#Endereco").val("");
    $("#Bairro").val("");
    $("#Cidade").val("");
    $("#Estado").val("");
}

$(document).ready(function () {
    $("#CEP").blur(function () {

        var cep = $(this).val().replace(/\D/g, '');

        $('.CEPError').remove();
        if (cep != "") {
            var validacep = /^[0-9]{8}$/;

            if (validacep.test(cep)) {

                LimparCamposEndereco();

                $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                    if (!("erro" in dados)) {

                        $("#Endereco").val(dados.logradouro);
                        $("#Bairro").val(dados.bairro);
                        $("#Cidade").val(dados.localidade);
                        $("#Estado").val(dados.uf);
                    }
                    else {
                        LimparCamposEndereco();
                        $('#CEP').after('<div class="text-danger CEPError">CEP não encontrado.</div>');
                    }
                });
            }
            else {
                LimparCamposEndereco();
                $('#CEP').after('<div class="text-danger CEPError">Formato de CEP inválido.</div>');
            }
        }
        else {
            limpa_formulário_cep();
        }
    });
});


function TestaCPF(strCPF) {
    var Soma;
    var Resto;
    Soma = 0;

    if (strCPF == "00000000000" || strCPF == '11111111111' || strCPF == '22222222222' || strCPF == '33333333333' || strCPF == '44444444444' || strCPF == '55555555555' || strCPF == '66666666666' || strCPF == '77777777777' || strCPF == '88888888888' || strCPF == '99999999999')
        return false;
    for (i = 1; i <= 9; i++)
        Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (11 - i);
    Resto = (Soma * 10) % 11;
    if ((Resto == 10) || (Resto == 11))
        Resto = 0;
    if (Resto != parseInt(strCPF.substring(9, 10)))
        return false;
    Soma = 0;
    for (i = 1; i <= 10; i++)
        Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (12 - i);
    Resto = (Soma * 10) % 11;
    if ((Resto == 10) || (Resto == 11))
        Resto = 0;
    if (Resto != parseInt(strCPF.substring(10, 11)))
        return false;
    return true;
}

function validarCNPJ(cnpj) {

    cnpj = cnpj.replace(/[^\d]+/g, '');

    if (cnpj == '') return false;

    if (cnpj.length != 14)
        return false;

    // Elimina CNPJs invalidos conhecidos
    if (cnpj == "00000000000000" ||
        cnpj == "11111111111111" ||
        cnpj == "22222222222222" ||
        cnpj == "33333333333333" ||
        cnpj == "44444444444444" ||
        cnpj == "55555555555555" ||
        cnpj == "66666666666666" ||
        cnpj == "77777777777777" ||
        cnpj == "88888888888888" ||
        cnpj == "99999999999999")
        return false;

    // Valida DVs
    tamanho = cnpj.length - 2
    numeros = cnpj.substring(0, tamanho);
    digitos = cnpj.substring(tamanho);
    soma = 0;
    pos = tamanho - 7;
    for (i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2)
            pos = 9;
    }
    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado != digitos.charAt(0))
        return false;

    tamanho = tamanho + 1;
    numeros = cnpj.substring(0, tamanho);
    soma = 0;
    pos = tamanho - 7;
    for (i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2)
            pos = 9;
    }
    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado != digitos.charAt(1))
        return false;

    return true;
}

function bootboxConfirm(title, callback) {
    bootbox.confirm({
        message: title,
        buttons: {
            confirm: {
                label: 'Sim',
                className: 'btn-success'
            },
            cancel: {
                label: 'Não',
                className: 'btn-danger mr-auto float-left'
            }
        },
        callback: callback
    });
}