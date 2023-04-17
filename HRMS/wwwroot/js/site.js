function FillPosition(listDepartmentCtrl, listPositionCtrl) {
    var listPosition = $("#" + listPositionCtrl);
    listPosition.empty();

    var selectedDepartment = listDepartmentCtrl.options[listDepartmentCtrl.selectedIndex].value;

    if (selectedDepartment != null && selectedDepartment != '') {
        $.getJSON("/Account/GetPositionByDepartment", { departmentId: selectedDepartment }, function (positions) {
            if (positions != null && positions.length > 0) {
                $.each(positions, function (index, position) {
                    listPosition.append($('<option/>', {
                        value: position.value,
                        text: position.text
                    }));
                });
            }
            else {
                listPosition.append($('<option/>', {
                    value: '',
                    text: 'No positions found'
                }));
            }
        });
    }
    else {
        listPosition.append($('<option/>', {
            value: '',
            text: 'Select a department first'
        }));
    }
}
