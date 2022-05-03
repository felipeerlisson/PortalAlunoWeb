//Mascara CEP
function MascaraCEP(elementId) {
    let zipCode = "";
    var elementoId = document.getElementById(elementId);
    zipCode = elementoId.value;

    if (zipCode) {
        zipCode = zipCode.replace('-', '');
        elementoId.setAttribute("maxlength", "8");
        if (zipCode.length === 8) {
            elementoId.value = `${zipCode.substr(0, 5)}-${zipCode.substr(5, 9)}`;
        }
        else {
            elementoId.value = zipCode;
        }
    }
}