//VERIFICA SE TODOS OS CHECKBOXS ESTÃO SELECIONADOS PARA PROCEGUIR
function VerificationCheck() {
    if ($("input#customCheck6").prop('checked') && $("input#customCheck5").prop('checked') && $("input#customCheck3").prop('checked') && $("input#customCheck").prop('checked')) {
        document.getElementById("hiddenButton").setAttribute("style", "visibility: visible");
    } else {
        document.getElementById("hiddenButton").setAttribute("style", "visibility: hidden");
    }
}
$(document).ready(function () {

    //SELECIONA SIM E NÃO E CHAMA FUNÇÃO
    $("input#customCheck").click(function () {
        $("input#customCheck2").prop("checked", false),
            $("input#customCheck").prop("checked", true);
        VerificationCheck();
    });
    $("input#customCheck2").click(function () {
        $("input#customCheck").prop("checked", false),
            $("input#customCheck2").prop("checked", true);

    });

    $("input#customCheck3").click(function () {
        $("input#customCheck4").prop("checked", false),
            $("input#customCheck3").prop("checked", true);
        VerificationCheck();
    });
    $("input#customCheck4").click(function () {
        $("input#customCheck3").prop("checked", false),
            $("input#customCheck4").prop("checked", true);

    });

    //CHAMA FUNÇÃO
    $("input#customCheck5").click(function () {
        VerificationCheck();
    });
    $("input#customCheck6").click(function () {
        VerificationCheck();
    });

});