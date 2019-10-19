(
    function (publicMethod, $) {
        publicMethod.pageLoad = function () {
            //$(".navMenuItem").click(function () {
            //    homeController.showLoadingIndicator();
            //});

            $(window).on('hashchange', function (e) {
                homeController.showLoadingIndicator();
            });
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

        publicMethod.reloadPage = function () {
            location.reload();
        }

        publicMethod.redirectToPage  = function (url) {
            window.location.href = "/" + url;
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

        publicMethod.showSuccessToastNotification = function (message) {
            const Toast = Swal.mixin({
                toast: true,
                position: 'top-end',
                showConfirmButton: false,
                timer: 3000
            })

            Toast.fire({
                type: 'success',
                title: message
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
            $(".navMenuItem").removeClass("active");

            setTimeout(
                function () {
                    $("#" + navId).addClass("active");
                }, 500);
        }

        publicMethod.loadClaimsAController = function () {
            $.getScript("./jsControllers/claimsAController.js", function (data, textStatus, jqxhr) {
            });
        }
    }(window.homeController = window.homeController || {}, jQuery)
);