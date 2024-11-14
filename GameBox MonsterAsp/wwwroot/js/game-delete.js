$(document).ready(function () {
    $('.js-delete').on('click', function () {
        var btn = $(this);
        var gameId = btn.data('id');  // Get the game ID from the button's data attribute

        const swal = Swal.mixin({
            customClass: {
                confirmButton: 'btn btn-danger mx-2',
                cancelButton: 'btn btn-light'
            },
            buttonsStyling: false
        });

        swal.fire({
            title: 'Are you sure you want to delete this game?',
            text: "This action cannot be undone!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Yes, delete it!',
            cancelButtonText: 'No, cancel!',
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `/Games/Delete/${gameId}`,  // Use the game ID in the URL
                    type: 'POST',  // Use POST as the method type
                    success: function () {
                        swal.fire(
                            'Deleted!',
                            'Game has been deleted.',
                            'success'
                        ).then(() => {
                            window.location.href = '/Games/Index';  // Redirect to the Index page
                        });
                    },
                    error: function () {
                        swal.fire(
                            'Oops...',
                            'Something went wrong!',
                            'error'
                        );
                    }
                });
            }
        });
    });
});
