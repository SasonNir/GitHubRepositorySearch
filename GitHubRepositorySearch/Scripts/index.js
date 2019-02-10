$("#GitBtnSearch").click(function () {
    var value = $("#GitTextForSearch").val();
    if (value !== null && value.trim() !== "") {
        getGitHubResult(value.trim());
    }
});

$("#GitTextForSearch").keypress(function (e) {
    if (e.which === 13) {//13 is enter key
        var value = $(this).val();
        if (value !== null && value.trim() !== "") {
            getGitHubResult(value.trim());
        }
    }
});

function getGitHubResult(value) {
    var url = $("#main").data("github-get-results-url");
    if (url !== null && url !== "") {
        $.post(url, { inputSearch: value }, function (data) {
            if (data !== null) {
                showDataInTable(data.Items);
            }
        });
    }
}

function showDataInTable(items) {
    $('#repositoriesResults tr').remove();
    var repositoriesItemsTableBody = $('#repositoriesResults');
    var row;
    $.each(items, function (index, value) {
        row = [];
        row.push('<tr id="item');
        row.push(index);
        row.push('"><td style="width:33%;">');
        row.push(value.Name);
        row.push('</td><td style="width:33%;"><img style="width:30px;heigth:30px;" src=');
        row.push(value.Owner.AvatarOwner);
        row.push('/></td><td style="width:33%;"><button onclick="saveResult(');
        row.push(index);
        row.push(')" class="btn btn-default">Bookmark</button></td></tr>');
        $(repositoriesItemsTableBody).append(row.join(""));
    });
}

function saveResult(itemIndex) {
    //alert(itemIndex);
    var tr = $("#item" + itemIndex);

    var name = $(tr).find("td").eq(0).text();
    var owner = $(tr).find("td").eq(1).find("img")[0].src;
    var url = $("#main").data("github-save-result-url");
    if (url !== null && url !== "") {
        $.post(url, { rowIndex: tr[0].id, repositoryName: name, repositoryOwner: owner }, function (data) {
            if (data !== null) {
                if (data) {
                    alert("Data saved!");
                }
            }
        });
    }
}