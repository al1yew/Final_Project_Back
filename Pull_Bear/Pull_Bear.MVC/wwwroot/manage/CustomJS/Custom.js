$(document).ready(function () {


    //----------------------------------------------- Category toggle class when it is main or child

    $(document).on('change', '.isMaininput', function () {
        if ($(this).is(":checked")) {
            $('.imagecont').show();
            $('.parentcontainer').hide();
            $('.ismaleselect').val('');
            $('.isfemaleselect').val('');
        } else {
            $('.parentcontainer').show();
            $('.imagecont').hide();
        }
    })


    //----------------------------------------------- Toggle Gender Select option in Category Create View

    $(document).on('change', '.genderselect', function () {

        if ($(this).val() == 1) {

            $('.ismale').hide();
            $('.ismaleselect').val('');
            $('.isfemale').show();
        }
        else if ($(this).val() == 2) {

            $('.isfemaleselect').val('');
            $('.ismale').show();
            $('.isfemale').hide();
        }
        else if ($(this).val() == 0) {
            $('.ismale').hide()();
            $('.isfemale').hide();
            $('.isfemaleselect').val('');
            $('.ismaleselect').val('');
        }
    });


    //----------------------------------------------- Clear another select option val in Category Create view 

    $(document).on('change', '.ismaleselect', function () {
        $('.isfemaleselect').val('');
    });

    $(document).on('change', '.isfemaleselect', function () {
        $('.ismaleselect').val('');
    });


    //----------------------------------------------- remove product create onclick added fields

    $(document).on('click', '.removeinps', function () {
        console.log($('.hamsi').length)
        if ($('.hamsi').length >= 2) {

            $(this).parent().remove();
        }
    });


    //----------------------------------------------- Search Layout

    $(".layoutsearch").keyup(function () {

        let inputvalue = $(this).val();

        $('.closesearch').show();

        let url = $(this).data('url');

        url = url + '?search=' + inputvalue;

        if (inputvalue) {

            fetch(url)
                .then(res => res.text())
                .then(data => {
                    $(".search-body-adminarea .list-group-layout").html(data);
                    $('.search-body-adminarea').removeClass("d-none")
                    if (data.trim() == '') {
                        $('.search-body-adminarea').addClass("d-none")
                        $('.search-body-adminarea ul').addClass("d-none")
                    }
                    else {
                        $('.search-body-adminarea').removeClass("d-none")
                        $('.search-body-adminarea ul').removeClass("d-none")
                    }
                })
        }
        else {
            $(".search-body-adminarea .list-group-layout").html('');
            $('.search-body-adminarea').addClass("d-none")
            $('.closesearch').hide();
        }
    });

    $(document).on('click', '.closesearch', function () {
        $('.search-body-adminarea').addClass("d-none");
        $('.layoutsearch').val('');
        $('.closesearch').hide();
    });


    //----------------------------------------------- catch element update delete restore and set in search menu

    $(document).on('click', '.fordel, .forres', function (e) {

        e.preventDefault();

        url = $(this).attr('href');

        let inputvalue = $('.layoutsearch').val();

        let searchurl = $('.layoutsearch').data('url');

        searchurl = searchurl + '?search=' + inputvalue;

        fetch(url)
            .then(res => res.text())
            .then(data => {
                fetch(searchurl)
                    .then(res => res.text())
                    .then(data => $(".search-body-adminarea .list-group-layout").html(data))
            })
    });


    //----------------------------------------------- get color name with api 

    $(document).on("click", ".apiclick", function () {

        let url = "https://api.color.pizza/v1/";

        let value = $(this).prev().val().toString().trim();

        let newvalue = value.substring(value.indexOf("#") + 1, 7)

        let regex = /^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$/

        let newurl = url + newvalue;

        if (regex.test(value)) {
            fetch(newurl)
                .then(res => res.json())
                .then(data => {
                    $('.fromapi').val(data.paletteTitle);
                });
        }
    });


    //----------------------------------------------- Add additional input fields for product create view

    $(document).on('click', '.addfields', function (e) {

        e.preventDefault();

        fetch($(this).attr('href'))
            .then(res => res.text())
            .then(data => {
                $('.inpustcontainer').append(data)
            })

    });

    $(document).on('click', '.addinputs', function (e) {
        e.preventDefault();

        fetch($(this).attr('href'))
            .then(res => res.text())
            .then(data => {
                $('.inputsContainer').append(data)
            })
    })








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