(
    function (publicMethod, $) {
        publicMethod.showAjaxErrorMessagePopUp = function (xMLHttpRequest, textStatus, errorThrown) {
        }

        publicMethod.showAlert = function () {
          
        }


        publicMethod.signedInSuccessfully = function (modalId) {
            const Toast = Swal.mixin({
                toast: true,
                position: 'top-end',
                showConfirmButton: false,
                timer: 3000
            })

            Toast.fire({
                type: 'success',
                title: 'Signed in successfully'
            })
        }

        publicMethod.loggedOutSuccessfully = function (modalId) {
            const Toast = Swal.mixin({
                toast: true,
                position: 'top-end',
                showConfirmButton: false,
                timer: 3000
            })

            Toast.fire({
                type: 'success',
                title: 'Logged out successfully'
            })
        }


        publicMethod.setActiveNavBar = function (navId) {
            $("#" + navId).addClass("active");
            //setTimeout(
            //    function () {
            //        $("#" + navId).addClass("active");
            //    }, 1000);
        }
    }(window.homeController = window.homeController || {}, jQuery)
);