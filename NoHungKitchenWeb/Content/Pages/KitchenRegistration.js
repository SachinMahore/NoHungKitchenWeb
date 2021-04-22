var saveregistration = function () {
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

    //if (uploaddocuments.files.length > 0) {
    //    for (var i = 0; i < uploaddocuments.files.length; i++) {
    //        $formData.append('file-' + i, uploaddocuments.files[i]);
    //    }
    //}
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
            alert("Registration successfully");
        }

    });
}