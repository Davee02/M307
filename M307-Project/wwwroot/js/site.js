function getNewRepairEndDateForSeverity(severity, startDate) {
    let endDate;

    switch (severity) {
        case "0":
            endDate = addDays(startDate, 25);
            break;
        case "1":
            endDate = addDays(startDate, 20);
            break;
        case "3":
            endDate = addDays(startDate, 10);
            break;
        case "4":
            endDate = addDays(startDate, 5);
            break;
        default:
            endDate = addDays(startDate, 15);
            break;
    }

    return endDate;
}

function addDays(date, days) {
    const result = new Date(date);
    result.setDate(result.getDate() + days);
    return result;
}

function writeDeadlineEmoji(severity, startDate) {
    const endDate = getNewRepairEndDateForSeverity(severity, startDate);

    if (endDate > new Date()) {
        document.write("👍");
    } else {
        document.write("👎");
    }
}

function finishOrders() {
    const checkboxes = document.querySelectorAll("input[type=checkbox]:checked");
    const allIds = [];

    checkboxes.forEach(function (element) {
        allIds.push(element.value);
    });

    if (allIds.length > 0) {
        $.post("/RepairOrders/FinishOrders", { ids: allIds })
            .always(function () {
                location.reload(true);
            });
    }
}