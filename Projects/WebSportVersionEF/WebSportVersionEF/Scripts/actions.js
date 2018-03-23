$(function () {

    function ajaxDelConfirm(route, hash) {
        hash = hash !== "" ? hash : "del-success";

        $.ajax({
            method: 'post',
            url: route
        }).done(function () {
            window.location.hash = hash;
            window.location.reload();
        }).fail(function () {
            $.notify("Echec de la suppression", "error");
        })
    }
    
    var thash = window.location.hash;
    if (thash.indexOf("del-success") > -1) {
        $.notify("Suppression réussit", "success");
    } else if (thash.indexOf("gen-success") > -1) {
        $.notify("Génération réussit", "success");
    }
    window.location.hash = "";

    $('.delete-item').on('click', function (e) {
        e.preventDefault();
        var route = this.href;
        swal({
            title: 'Confirmer ?',
            text: 'Vous êtes sur le point de supprimer cet élément',
            icone: 'warning',
            buttons: true,
            dangerMode: true,
        }).then((willDelete) => {
            if (willDelete) {
                ajaxDelConfirm(route);
            }
        })
    });

    $('.delete-datas').on('click', function (e) {
        e.preventDefault();
        var route = "/Home/RemoveAllDatas";
        swal({
            title: 'Confirmer ?',
            text: 'Vous êtes sur le point de supprimer tous les éléménts de la base de données',
            icone: 'warning',
            buttons: true,
            dangerMode: true,
        }).then((willDelete) => {
            if (willDelete) {
                ajaxDelConfirm(route);
            }
        })
    });

    $('.fake-datas').on('click', function (e) {
        e.preventDefault();
        var route = "/Home/GenerateFakes";
        swal({
            title: 'Confirmer ?',
            text: 'Vous êtes sur le point de remplir la base de données de fixtures',
            icone: 'warning',
            buttons: true,
            dangerMode: true,
        }).then((willDelete) => {
            if (willDelete) {
                ajaxDelConfirm(route, "gen-success");
            }
        })
    });

    if (vbMess) {
        $.notify(vbMess, "default");
    }

    var inDates = $('form input[type="date"]');
    
    /**
    * Formatte les date pour affichage dans widget html 5
    */
    $.each(inDates, function (index, data) {
        var dt = $(data).attr('value');
        
        if (dt != "") {
            var day, month, year;
            
            if (typeof dt == "string" && dt.indexOf("/") > -1) {
                var dtSpl = dt.split("/");
                day = dtSpl[0], month = dtSpl[1], year = dtSpl[2];
            } else {
                var date = new Date(dt);
                day = date.getDate();
                month = date.getMonth() + 1;
                year = date.getFullYear();
                day = day.length > 1 ? day : "0" + day;
                month = month.length > 1 ? month : "0" + month;
            }

            var html5DFormat = year + "-" + month + "-" + day;
            data.value = html5DFormat;
        }
    });

    $('table.table').DataTable();

});