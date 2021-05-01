
var saveregistration = function () {
    $("#divLoader").show();
    var message = "";
    $formData = new FormData();
    var kitchenname = $("#txtKitchenName").val();
    var mobile = $("#txtMobile").val();
    var email = $("#txtEmail").val();
    var state = $("#ddlState").val();
    var city = $("#ddlCity").val();
    var pin = $("#txtPin").val();
    var address = $("#txtAddress").val();
    var ownername = $("#txtOwnerName").val();
    var password = $("#txtPassword").val();
    var uploaddocuments = document.getElementById("FUDocument");
    var kitchenimg = document.getElementById("FUKitchen");
    var menuimg = document.getElementById("FUMenu");
    var contactperson = $("#txtContactPerson").val();
    var contactpersonrole = $("#txtContactPersonRole").val();
    var kitchencontactno = $("#txtKitchenContactNo").val();
    var fssailicenseno = $("#txtFSSAILicenseNo").val();
    var expirydateoflicense = $("#txtExpiryDateOfLicense").val();
    var pancardno = $("#txtPanCardNo").val();
    var gstregno = $("#txtGSTRegNo").val();

    if (kitchenimg.files.length > 0) {
        for (var i = 0; i < kitchenimg.files.length; i++) {
            $formData.append('file-' + i, kitchenimg.files[i]);
        }
    }
    if (uploaddocuments.files.length > 0) {
            for (var i = 0; i < uploaddocuments.files.length; i++) {
                $formData.append('file-' + i, uploaddocuments.files[i]);
            }
    }
    if (menuimg.files.length > 0) {
        for (var i = 0; i < menuimg.files.length; i++) {
            $formData.append('file-' + i, menuimg.files[i]);
        }
    }
    if (kitchenname == "") {
        message += "Please Enter Kitchen Name</br>";
    }if (mobile == "") {
        message += "Please Enter Kitchen Contact</br>";
    } if (email == "") {
        message += "Please Enter Kitchen Email</br>";
    }
    if (address == "") {
        message += "Please Enter Kitchen Address</br>";
    }
    if (ownername == "") {
        message += "Please Enter Kitchen Owner Name</br>";
    }
    if (pancardno == "") {
        message += "Please Enter Pan Card No.</br>";
    }
    if (fssailicenseno == "") {
        message += "Please Enter FASSAI No.</br>";
    }
    if (pin == "") {
        message += "Please Enter Pin No.</br>";
    }
    if (kitchenimg.files.length == 0) {
        message += "Please upload Kitchen Logo/Photo</br>";
    }
    if (uploaddocuments.files.length == 0) {
        message += "Please upload Kitchen Registration Certificate</br>";         
    }
    if (menuimg.files.length == 0) {
        message += "Please upload Kitchen Menu Image";       
    }
    if (message == "") {
        $formData.append('KitchenName', kitchenname);
        $formData.append('Mobile', mobile);
        $formData.append('Email', email);
        $formData.append('State', state);
        $formData.append('City', city);
        $formData.append('Pin', pin);
        $formData.append('Address', address);
        $formData.append('OwnerName', ownername);
        $formData.append('Password', password);
        $formData.append('UploadDocuments', uploaddocuments);
        $formData.append('KitchenImage', kitchenimg);
        $formData.append('MenuImage', menuimg);
        $formData.append('ContactPerson', contactperson);
        $formData.append('ContactPersonRole', contactpersonrole);
        $formData.append('KitchenContactNo', kitchencontactno);
        $formData.append('FSSAILicenseNo', fssailicenseno);
        $formData.append('ExpiryDateOfLicense', expirydateoflicense);
        $formData.append('PanCardNo', pancardno);
        $formData.append('GSTRegNo', gstregno);


        $.ajax({
            url: "/Registration/SaveRegistration",
            method: "Post",
            data: $formData,
            contentType: false,
            dataType: "json",
            processData: false,

            success: function (response) {
                $("#divLoader").hide();
                $.alert({
                    title: 'Alert!',
                    content: response.message,
                    type: 'blue'
                });
                setTimeout(function () { window.location = '/Login'; }, 3000);

            }

        });
    } else {
        $.alert({
            title: 'Alert!',
            content: message,
            type: 'red'
        });
    
    }
}