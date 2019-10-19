(
    function (publicMethod, $) {
        publicMethod.pageLoad = function () {
            //$(".navMenuItem").click(function () {
            //    homeController.showLoadingIndicator();
            //});
        }

        publicMethod.showAjaxErrorMessagePopUp = function (xMLHttpRequest, textStatus, errorThrown) {
        }

        publicMethod.showAlert = function (message) {
            alert(message);
        }

        publicMethod.messageShowModal = function (message) {
            $('#messageShowModal').modal('show');
            $('#messageShowModalMessage').text(message);
        }

        publicMethod.showLoadingIndicator = function () {
            document.getElementById("myNav").style.height = "100%";
        }

        publicMethod.hideLoadingIndicator = function () {
            setTimeout(
                function () {
                    document.getElementById("myNav").style.height = "0%";
                }, 500);
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
        }

        publicMethod.loadClaimsAController = function () {
            $.getScript("./jsControllers/claimsAController.js", function (data, textStatus, jqxhr) {
            });
        }
    }(window.homeController = window.homeController || {}, jQuery)
);