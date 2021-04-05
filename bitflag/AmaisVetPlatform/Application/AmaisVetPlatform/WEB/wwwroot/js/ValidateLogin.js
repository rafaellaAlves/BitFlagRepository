$(document).ready(function () {
    $("#form-login").validate({

        onkeyup: function (element) {
            this.element(element);
        },
        onfocusout: function (element) {
            this.element(element);
        },
        rules: {
            Username: {
                required: true,
                minlength: 5,
                maxlength: 20

            },
            Password: {
                required: true,
                minlength: 8
            },
            mensagem: {
                rangelength: [50, 1050],
            }
        },
        messages: {
            Usename: {
                required: "Este campo deve ser preenchido.",
                minlength: "Digite no mínimo 5 caracteres.",
                maxlength: "Digite no maxímo 20 caracteres."

            },
            Password: {
                required: "Este campo deve ser preenchido.",
                minlength: "Digite no mínimo 8 caracteres."
            },
            mensagem: {
                required: "D",
                minlength: "Mínimo de caracteres permitidos 50",
                maxlength: "Maxímo de caracteres permitidos 1050"
            },
        }
    });
});