 
  function togglePasswordVisibility(){
    var x = document.getElementById("exampleInputPassword1");
    if (x.type === "password") {
        x.type = "text";
        console.log("hi1")
    } else {
        x.type = "password";
        console.log("hi2")
    }
  }

  document.getElementById('colorButton').addEventListener('click', function() {
    var navbar = document.getElementById('navbar');
    navbar.classList.toggle('changedColor');
  });

  const phoneInputField = document.querySelector("#phone2");
  const phoneInput = window.intlTelInput(phoneInputField, {
    utilsScript:
      "https://cdnjs.cloudflare.com/ajax/libs/intl-tel-input/17.0.8/js/utils.js",
  });

  const phoneInputPatient= document.querySelector("#phone");
  const phoneInputP = window.intlTelInput(phoneInputPatient, {
    utilsScript:
      "https://cdnjs.cloudflare.com/ajax/libs/intl-tel-input/17.0.8/js/utils.js",
  });


function checkEmailAvailibility() {
    var email = $(".fetchEmail").val();

    $.ajax({
        method: "POST",
        url: "/Patient/checkEmailAvailibility",
        data: { email: email },

        success: function (resp) {
            if (resp.code == 401) {
                $(".passwordField").css("display", "none");
            }
            else if (resp.code == 402) {
                $(".passwordField").css("display", "block");
            }
        },

        error: function () {
            console.log("Meet");
        }
    })
}