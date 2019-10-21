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

        publicMethod.messageShowModal = function (header, message) {
            if (header == "") {
                header = "Message";
            }

            $('#messageShowModalHeader').text(header);
            $('#messageShowModalMessage').text(message);
            $('#messageShowModal').modal('show');
        }

        publicMethod.messageShowModalNoBtnAutoHide = function (header, message) {
            if (header == "") {
                header = "Message";
            }

            $('#messageShowModalNoBtnAutoHideHeader').text(header);
            $('#messageShowModalNoBtnAutoHideMessage').text(message);
            $('#messageShowModalNoBtnAutoHide').modal('show');

            setTimeout(
                function () {
                    $('#messageShowModalNoBtnAutoHide').modal('hide');
                }, 3500);
        }

        publicMethod.reloadPage = function () {
            location.reload();
        }

        publicMethod.redirectToPage = function (url) {
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

        publicMethod.loadApprovalsController = function () {
            $.getScript("./jsControllers/approvalsController.js", function (data, textStatus, jqxhr) {
            });
        }
    }(window.homeController = window.homeController || {}, jQuery)
);