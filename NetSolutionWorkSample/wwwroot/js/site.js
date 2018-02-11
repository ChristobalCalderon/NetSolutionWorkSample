$(function () {

    $("#jsGrid").jsGrid({
        width: "100%",
        height: "800px",

        inserting: false,
        editing: false,
        sorting: true,

        rowClick: function (args) {
            showDetailsDialog("Edit", args.item);
        },

        fields: [
            { name: "ID", type: "number", width: 150, validate: "required" },
            { name: "Title", type: "text", width: 50 },
            { name: "Overview", type: "text", width: 200 },
            { type: "control" }
        ]
    });

    $("#movieInput").keyup(function () {
        var input = $("#movieInput").val()

        $.ajax({
            url: "/Home/SearchMovieByName",
            type: "POST",
            data: {
                searchName: input
            }
        }).done(function (data) {
            var db = [];

            $(data.results).each(function (index) {
                db.push({
                    "ID": data.results[index].id,
                    "Title": data.results[index].title,
                    "Overview": data.results[index].overview
                });
            });

            $("#jsGrid").jsGrid({
                data: db
            });
        });
    });

    window.onPageSelect = function () {
        var pageNr = parseInt($("#pager").val(), 10);

        $.ajax({
            url: "/Home/TopRatedMovies",
            type: "POST",
            data: {
                page: pageNr
            }
        }).done(function (data) {
            var db = [];

            $(data.results).each(function (index) {
                db.push({
                    "ID": data.results[index].id,
                    "Title": data.results[index].title,
                    "Overview": data.results[index].overview
                });
            });

            $("#jsGrid").jsGrid({
                data: db
            });
        });
    };

    $("#pager").on("change", onPageSelect);

    $(function () {
        var s = $("#pager");

        for (var i = 1; i <= 1000; i++) {
            $("<option />", { value: i, text: i }).appendTo(s);
        }

        $(s).wrap('<table><tr><td></td></tr></table>');
    });

})

function openMovies(evt, Movies) {



    if (Movies == "FreeSearch") {
        $("#pagerWrapper").hide();
    } else {
        $("#pagerWrapper").show();

        //Always start from page 1 when switching between tabs
        $("#pager").val(1);
        onPageSelect();
    }

    var i, tabcontent, tablinks;
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }
    document.getElementById(Movies).style.display = "block";
    evt.currentTarget.className += " active";
};



