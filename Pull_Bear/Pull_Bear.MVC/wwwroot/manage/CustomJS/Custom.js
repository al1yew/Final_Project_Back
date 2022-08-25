$(document).ready(function () {

    //----------------------------------------------- Category toggle class when it is main or child

    $(document).on('change', '.isMaininput', function () {
        if ($(this).is(":checked")) {
            $('.parentcontainer').hide();
            $('.ismaleselect').val('');
            $('.isfemaleselect').val('');
        } else {
            $('.parentcontainer').show();
        }
    })

    //----------------------------------------------- Toggle Gender Select option in Category Create View

    //$(document).on('change', '.genderselect', function () {

    //    if ($(this).val() == 1) {

    //        $('.ismale').hide();

    //        $('.isfemale').show();
    //    }
    //    else if ($(this).val() == 2) {

    //        $('.ismale').show();

    //        $('.isfemale').hide();
    //    }

    //});

    ////----------------------------------------------- Clear another select option val in Category Create view

    //$(document).on('change', '.ismaleselect', function () {
    //    $('.isfemaleselect').val('');
    //});

    //$(document).on('change', '.isfemaleselect', function () {
    //    $('.ismaleselect').val('');
    //});

    //----------------------------------------------- Delete element

    $(document).on('click', '.deleteBtn', function (e) {
        e.preventDefault();

        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            padding: '3em',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {

                let url = $(this).attr('href');

                fetch(url)
                    .then(res => res.text())
                    .then(data => { $('.tblContent').html(data) });

                Swal.fire(
                    'Deleted!',
                    '',
                    'success'
                )
            }
        });
    });


    //----------------------------------------------- Restore element

    $(document).on('click', '.restoreBtn', function (e) {
        e.preventDefault();

        Swal.fire({
            title: 'Are you sure?',
            padding: '3em',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, restore it!'
        }).then((result) => {
            if (result.isConfirmed) {

                let url = $(this).attr('href');

                fetch(url)
                    .then(res => res.text())
                    .then(data => { $('.tblContent').html(data) });

                Swal.fire(
                    'Restored!',
                    '',
                    'success'
                )
            }
        });
    });



});