function checkForErrors(inputField) {
    var message = "";
    if (inputField.id == "country" && hasValue(inputField) == "false") {
        message = "This is a required field;";
    }
   

    var errorSpanId = "error-message-" + inputField.id;
    var errorSpanObject = document.getElementById(errorSpanId);
    errorSpanObject.textContent = "";
    errorSpanObject.style.display = "none";

    if (message != "") {
        errorSpanObject.textContent = message;
        errorSpanObject.style.display = "block";
    }



}


function hasValue(inputField) {

    if (inputField.value == "") {
        return "false";
    }

    return "true";
}

function validEmail(inputField) {

    var fieldHasValidEmail = "true";
    var trimmedinput = inputField.value.trim();
    var dotloc = trimmedinput.lastIndexOf(".");
    var atsignloc = trimmedinput.indexOf("@");

    if (atsignloc < 1 || (dotloc - atsignloc) < 2) {
        fieldHasValidEmail = "false";
    }
    return fieldHasValidEmail;
}

function submit_form() {
    document.getElementById("contactform").submit();
    return false;
}






