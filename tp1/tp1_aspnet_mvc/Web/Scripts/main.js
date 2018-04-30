console.info("Main");

$(document).ready(function () {
    var cbs = $('input[id*=checkbox_]');

    for (let i = 0; i < cbs.length; i++) {
        const cb = cbs[i].addEventListener('click', function () {
            var id = this.getAttribute("value");
            var nome = this.dataset.value;

            $.ajax(
                {
                    url: "/Friends/CreateCookie", 
                    method: "POST",
                    data: {
                        value: ValueCookieStringer()
                    }
                }
            )
            .done(function () {
                console.log("success");
            })
            .fail(function () {
                console.log("error");
            })
            .always(function () {
                console.log("complete");
            });
        });
    }


    function Pessoa(id, checked) {
        this.id = id;
        this.checked = checked;
    }

    function ValueCookieStringer() {

        var PessoasIDs = [];

        for (let i = 0; i < cbs.length; i++) {
            var id = cbs[i].getAttribute("value");
            var checked = ((cbs[i].checked) ? true : false);
            var pessoa = new Pessoa(id, checked);
            PessoasIDs.push(pessoa)
        }

        return JSON.stringify(PessoasIDs).toString();
    }

    function ReadCookie() {
        $.ajax(
            {
                url: "/Friends/ReadCookie",
                method: "POST",
            }
        )
        .done(function (data) {
            var array = JSON.parse(data);
            for (let i = 0; i < cbs.length; i++) {

                var cbsIntId = cbs[i].getAttribute("id").split("_")[1];
                if (cbsIntId == array[i].id && array[i].checked == true) {
                    cbs[i].setAttribute("checked", "checked");
                }
            }
        })
        .fail(function () {
            console.log("error");
        })
        .always(function () {
            console.log("complete");
        });
    }

    ReadCookie();

});