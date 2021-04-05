//VALIDA O CPF TRAZ INFORMAÇÕES RELACIONADAS
function Validate(o, callback) {
    $.ajax({
        type: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        url: '@Url.Action("ValidateCPF", "Account")',
        data: JSON.stringify(o),
        success: callback,
    })
        .done(function (name, email) {
            $('input[name="FullName"]').val("Rafaella Alves"),
                $('input[name="Email"]').val("rafaa.silvaa199@gmail.com");
        });
}

//FORM
$(document).ready(function () {
    $('input[name = Cpf]').mask('999.999.999-99');
    document.getElementById('BirthDate').max = new Date(new Date().getTime() - new Date().getTimezoneOffset() * 60000).toISOString().split("T")[0];


    //VALIDA CPF CHAMA  A FUNCTION
    $('button#valid').click(function () {
        $('#not-found').hide();
        $('#UpdateAccount').hide();
        Validate({
            "Cpf": $('input[name="Cpf"]').val()
        }, function (d) {
            /* *** APOS A REQUISICAO AJAX *** */
            if (d) {

                $('#UpdateAccount').show();
            } else {
                $('#not-found').show();
            }
        });

    });   

});