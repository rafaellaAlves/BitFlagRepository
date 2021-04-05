

$(document).ready(function () {
    document.getElementById('BirthDate').max = new Date(new Date().getTime() - new Date().getTimezoneOffset() * 60000).toISOString().split("T")[0];

    //MASCARA
    $('input[name = Cpf]').mask('999.999.999-99');


    //VALIDADOR DE CPF
    jQuery.validator.addMethod('cpf', function (value, element) {
        value = jQuery.trim(value);

        value = value.replace('.', '');
        value = value.replace('.', '');
        cpf = value.replace('-', '');
        while (cpf.length < 11) cpf = "0" + cpf;
        var expReg = /^0+$|^1+$|^2+$|^3+$|^4+$|^5+$|^6+$|^7+$|^8+$|^9+$/;
        var a = [];
        var b = new Number;
        var c = 11;
        for (i = 0; i < 11; i++) {
            a[i] = cpf.charAt(i);
            if (i < 9) b += (a[i] * --c);
        }
        if ((x = b % 11) < 2) { a[9] = 0 } else { a[9] = 11 - x }
        b = 0;
        c = 11;
        for (y = 0; y < 10; y++) b += (a[y] * c--);
        if ((x = b % 11) < 2) { a[10] = 0; } else { a[10] = 11 - x; }

        var retorno = true;
        if ((cpf.charAt(9) != a[9]) || (cpf.charAt(10) != a[10]) || cpf.match(expReg)) retorno = false;

        return this.optional(element) || retorno;

    }, "Informe um CPF válido.");


    
    //VALIDA O FORM
    $("#UpgradeSubscription").validate({
        onkeyup: function (element) {
            this.element(element);
        },
        onfocusout: function (element) {
            this.element(element);
        },
        rules: {
            FullName: {
                required: true,
                minlength: 5,
                maxlength: 30

            },
            BirthDate: {
                required: true
            },
            Cpf: {
                required: true,
                cpf: true
            },
            Crmv: {
                required: true,
                number: true
            },
            Reference: {
                minlength: 8,
                maxlength: 8
            },
            mensagem: {
                rangelength: [50, 1050],
            }
        },
        messages: {
            FullName: {
                required: "Este campo deve ser preenchido.",
                minlength: "Digite no mínimo 5 caracteres.",
                maxlength: "Digite no maxímo 30 caracteres."

            },
            BirthDate: {
                required: "Este campo deve ser preenchido."
            },
            Cpf: {
                required: "Este campo deve ser preenchido."
            },
            Crmv: {
                required: "Este campo deve ser preenchido.",
                number: "Informe apenas números."
            },
            Reference: {
                minlength: "A referencia possui 8 caracteres.",
                maxlength: "A referencia possui 8 caracteres."
            },
            mensagem: {
                required: "D",
                minlength: "Mínimo de caracteres permitidos 50",
                maxlength: "Maxímo de caracteres permitidos 1050"
            },
        }
    })
});