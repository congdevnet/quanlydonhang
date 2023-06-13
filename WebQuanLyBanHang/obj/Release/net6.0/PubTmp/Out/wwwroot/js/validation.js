var FormModalIsValid = true;
function ValidateRequireControl(el, errorMes) {
    $(el).removeClass('is-invalid')
    $(el).nextAll(".spanError").remove()
    if ($(el).val() == null || $(el).val() == undefined) {
        $(el).addClass('is-invalid')
        $(el).after(`<span class = "text-danger spanError"> ${errorMes}</span>`)
        FormModalIsValid = false
    }
    else {
        let valuectl = $(el).val().trim()
        if (valuectl == null || valuectl == '') {
            $(el).addClass('is-invalid')
            $(el).after(`<span class = "text-danger spanError"> ${errorMes}</span>`)
            FormModalIsValid = false
        }
    }
}

function CreateValidate(el, errorMes) {
    $(el).removeClass('is-invalid')
    $(el).nextAll(".spanError").remove()

    $(el).addClass('is-invalid')
    $(el).after(`<span class = "text-danger spanError"> ${errorMes}</span>`)
    FormModalIsValid = false

}

function ClearError(el) {
    $(el).removeClass('is-invalid')
    $(el).nextAll(".spanError").remove()
}

function ValidateRequireControlMaxLength(el, errorMes, length) {
    if (FormModalIsValid) {
        let valuectl = $(el).val().trim()
        if (valuectl != null && valuectl != '') {
            $(el).removeClass('is-invalid')
            $(el).nextAll(".spanError").remove()
            if (valuectl.length > length) {
                $(el).addClass('is-invalid')
                $(el).after(`<span class = "text-danger spanError"> ${errorMes}</span>`)
                FormModalIsValid = false
            }
        }
    }
}
function ValidateRequireControlMinLength(el, errorMes, length) {
    if (FormModalIsValid) {
        let valuectl = $(el).val().trim()
        if (valuectl != null && valuectl != '') {
            $(el).removeClass('is-invalid')
            $(el).nextAll(".spanError").remove()
            if (valuectl.length < length) {
                $(el).addClass('is-invalid')
                $(el).after(`<span class = "text-danger spanError"> ${errorMes}</span>`)
                FormModalIsValid = false
            }
        }
    }
}

function ValidateRequireControlPass(el1, el2, errorMes) {
    let valuectl1 = $(el1).val().trim()
    let valuectl2 = $(el2).val().trim()
    if (valuectl1 != null && valuectl1 != '' && valuectl2 != null && valuectl2 != '') {
        $(el2).removeClass('is-invalid')
        $(el2).nextAll(".spanError").remove()
        if (valuectl1 != valuectl2) {
            $(el2).addClass('is-invalid')
            $(el2).after(`<span class = "text-danger spanError"> ${errorMes}</span>`)
            FormModalIsValid = false
        }
    }
}

function ValidateRequireControlEmail(el, errorMes) {
    let valuectl = $(el).val().trim()
    $(el).removeClass('is-invalid')
    $(el).nextAll(".spanError").remove()
    if (FormModalIsValid) {
        if (ValidateEmail(valuectl) == false) {
            $(el).addClass('is-invalid')
            $(el).after(`<span class = "text-danger spanError"> ${errorMes}</span>`)
            FormModalIsValid = false
        }
    }
}


function ValidateNumber(el, errorMes) {
    let valuectl = $(el).val().trim()
    $(el).removeClass('is-invalid')
    $(el).nextAll(".spanError").remove()
    if (FormModalIsValid) {
        if (CheckIsNumber(valuectl) == false) {
            $(el).addClass('is-invalid')
            $(el).after(`<span class = "text-danger spanError"> ${errorMes}</span>`)
            FormModalIsValid = false
        }
    }
}


function ValidatePassword(el, errorMes) {
    let valuectl = $(el).val().trim()
    $(el).removeClass('is-invalid')
    $(el).nextAll(".spanError").remove()
    if (FormModalIsValid) {
        if (CheckPassword(valuectl) == false) {
            $(el).addClass('is-invalid')
            $(el).after(`<span class = "text-danger spanError"> ${errorMes}</span>`)
            FormModalIsValid = false
        }
    }
}
function ValidateEmail(mail) {
    if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(mail)) {
        return (true)
    }
    return (false)
}


// mật khẩu phải có 1 chữ hoa, 1 chữ thường , 1 số, 1 chữ cái đặc biệt, 8-15 kí tự
function CheckPassword(inputtxt) {
    let decimal = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{8,15}$/;
    if (inputtxt.match(decimal)) {
        return true
    }
    return false
}
function CheckIsNumber(num) {
    if (Number.isInteger(Number(num))) {
        return true
    }
    return false
}

function removeVietnameseTones(str) {
    str.toLowerCase()
    str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
    str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
    str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
    str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
    str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
    str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
    str = str.replace(/đ/g, "d");
    str = str.replace(/À|Á|Ạ|Ả|Ã|Â|Ầ|Ấ|Ậ|Ẩ|Ẫ|Ă|Ằ|Ắ|Ặ|Ẳ|Ẵ/g, "A");
    str = str.replace(/È|É|Ẹ|Ẻ|Ẽ|Ê|Ề|Ế|Ệ|Ể|Ễ/g, "E");
    str = str.replace(/Ì|Í|Ị|Ỉ|Ĩ/g, "I");
    str = str.replace(/Ò|Ó|Ọ|Ỏ|Õ|Ô|Ồ|Ố|Ộ|Ổ|Ỗ|Ơ|Ờ|Ớ|Ợ|Ở|Ỡ/g, "O");
    str = str.replace(/Ù|Ú|Ụ|Ủ|Ũ|Ư|Ừ|Ứ|Ự|Ử|Ữ/g, "U");
    str = str.replace(/Ỳ|Ý|Ỵ|Ỷ|Ỹ/g, "Y");
    str = str.replace(/Đ/g, "D");
    // Some system encode vietnamese combining accent as individual utf-8 characters
    // Một vài bộ encode coi các dấu mũ, dấu chữ như một kí tự riêng biệt nên thêm hai dòng này
    str = str.replace(/\u0300|\u0301|\u0303|\u0309|\u0323/g, ""); // ̀ ́ ̃ ̉ ̣  huyền, sắc, ngã, hỏi, nặng
    str = str.replace(/\u02C6|\u0306|\u031B/g, ""); // ˆ ̆ ̛  Â, Ê, Ă, Ơ, Ư
    // Remove extra spaces
    // Bỏ các khoảng trắng liền nhau
    str = str.replace(/ + /g, " ");
    str = str.replace(/ /g, "_");
    str = str.trim();
    // Remove punctuations
    // Bỏ dấu câu, kí tự đặc biệt
    str = str.replace(/!|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\;|\'|\"|\&|\#|\[|\]|~|\$|`|{|}|\||\\/g, " ");
    return str;
};