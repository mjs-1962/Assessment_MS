
function showTab(n) {
    // This function will display the specified tab of the form ...
    var x = document.getElementsByClassName("tab");
    x[n].style.display = "block";
    // ... and run a function that displays the correct step indicator:
    
}

function jumpToTab(n) {
    // This function will figure out which tab to display
    var x = document.getElementsByClassName("tab");
    // Exit the function if any field in the current tab is invalid:
    /*if (n == 1 && !validateForm()) return false;*/
    // Hide the current tab:
    x[currentTab].style.display = "none";
    // Increase or decrease the current tab by 1:
    currentTab = n;
    // if you have reached the end of the form... :
    if (currentTab >= x.length) {
        //...the form gets submitted:
        document.getElementById("regForm").submit();
        return false;
    }
    // Otherwise, display the correct tab:
    showTab(currentTab);
}


function nextPrev(n) {
    // This function will figure out which tab to display
    var x = document.getElementsByClassName("tab");
    // Exit the function if any field in the current tab is invalid:
    /*if (n == 1 && !validateForm()) return false;*/
    // Hide the current tab:
    x[currentTab].style.display = "none";
    // Increase or decrease the current tab by 1:
    currentTab = currentTab + n;
    // if you have reached the end of the form... :
    if (currentTab >= x.length) {
        //...the form gets submitted:
        document.getElementById("regForm").submit();
        return false;
    }
    // Otherwise, display the correct tab:
    showTab(currentTab);
}

function validateForm() {
    // This function deals with validation of the form fields
    var x, y, i, valid = true;
    x = document.getElementsByClassName("tab");
    y = x[currentTab].getElementsByTagName("input");
    // A loop that checks every input field in the current tab:
    for (i = 0; i < y.length; i++) {
        // If a field is empty...
        if (y[i].value == "") {
            // add an "invalid" class to the field:
            y[i].className += " invalid";
            // and set the current valid status to false:
            valid = false;
        }
    }
    // If the valid status is true, mark the step as finished and valid:
    if (valid) {
        document.getElementsByClassName("step")[currentTab].className += " finish";
    }
    return valid; // return the valid status
}



function UpdateCheckLabel(labelName) {
    var currentValue = document.getElementById(labelName).value;
    var lblElement = document.getElementById("Label" + labelName);
    lblElement.innerHTML = currentValue;

}

function setBrightnessAcceptanceYes(trueOrFalse) {

    var YN = 'No'
    if (trueOrFalse == true) {
        YN = 'Yes'
    }
    var lblElement = document.getElementById('LabelBrightnessAcceptance');
    lblElement.innerHTML = YN;

}

function changePageAndUpdateCheckItems(n) {

    UpdateCheckLabel('FullName');
    UpdateCheckLabel('EmailAddress');
    UpdateCheckLabel('AddressLine1');
    UpdateCheckLabel('AddressLine2');
    UpdateCheckLabel('Town');
    UpdateCheckLabel('County');
    UpdateCheckLabel('Postcode');
    UpdateCheckLabel('BrightnessLevel');

    nextPrev(n)
}


function ValidateFullName() {
    var currentValue = document.getElementById("FullName").value;
    var lblElement = document.getElementById("FullNameValidation");

    if (currentValue.length == 0) {
        lblElement.innerHTML = "Please enter your full Name";
    } else if (currentValue.length > 50) {
        lblElement.innerHTML = "Value exceeds the maximum of 50 letters";
    } else {
        lblElement.innerHTML = "";
        changePageAndUpdateCheckItems(1);
    }


}

function ValidateEmailAddress() {
    var currentValue = document.getElementById("EmailAddress").value;
    var lblElement = document.getElementById("EmailAddressValidation");
    var re = new RegExp("/^[^\s@]+@[^\s@]+\.[^\s@]+$/");

    if (currentValue.length == 0) {
        lblElement.innerHTML = "Please enter your email address";
    } else if (currentValue.includes('@')) {
        changePageAndUpdateCheckItems(1);
    } else {
        lblElement.innerHTML = "Please enter a valid email address";
    }
}

function ValidateStringLength(inputId, validationId, maxLength, required, legend) {
    var currentValue = document.getElementById(inputId).value;
    var lblElement = document.getElementById(validationId);

    if (currentValue.length == 0) {
        lblElement.innerHTML = "Please enter a " + legend;
        return false;
    } else if (currentValue.length > maxLength) {
        lblElement.innerHTML = "Value exceeds the maximum of " + maxLength.toString + " letters";
        return false;
    } else {
        lblElement.innerHTML = "";
        return true;
    }

}


function ValidateAddress() {

    if (
        ValidateStringLength("AddressLine1", "AddressLine1Validation", 50, true, "Address Line 1") &&
        ValidateStringLength("Town", "TownValidation", 50, true, "Postal town") &&
        ValidateStringLength("Postcode", "PostcodeValidation", 50, true, "Pocode")
       )
    {
        changePageAndUpdateCheckItems(1);
    }
  
}

function ValidateBrightnessAcceptance() {

    var lblElement = document.getElementById("BrightnessAcceptanceValidation");

    try {
        var currentValue = document.getElementById("LabelBrightnessAcceptance").innerHTML;
        if (currentValue === undefined || currentValue === "") {
            lblElement.innerHTML = "please select yes or no";
        } else  {
            changePageAndUpdateCheckItems(1);
        }
    }
    catch (err) {
        lblElement.innerHTML = "please select yes or no";
    }
}

function ValidateBrightnessLevel() {

    var lblElement = document.getElementById("BrightnessLevelValidation");

    try {
        var currentValue = document.getElementById("BrightnessLevel").value;
        if (currentValue === undefined || currentValue === "" || currentValue === "choose") {
            lblElement.innerHTML = "please select a value between 1 and 10";
        } else {
            changePageAndUpdateCheckItems(1);
        }

    }
    catch (err) {
        lblElement.innerHTML = "please select a value between 1 and 10";
    }
}




