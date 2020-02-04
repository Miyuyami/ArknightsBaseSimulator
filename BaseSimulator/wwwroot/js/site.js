function BootstrapSwitch(elem, type, value) {
    $(elem).bootstrapSwitch(type, value);
}

function GetBootstrapSwitch(elem, type) {
    return $(elem).bootstrapSwitch(type);
}

var OnBootstrapSwitchFunctionCallbackName;
function SetOnBootstrapSwitch(elem, funcCallback) {
    $(elem).off("switchChange.bootstrapSwitch", OnSwitchChangeBootstrapSwitch);
    $(elem).on("switchChange.bootstrapSwitch", OnSwitchChangeBootstrapSwitch);

    OnBootstrapSwitchFunctionCallbackName = funcCallback;
}

function OnSwitchChangeBootstrapSwitch(event, state) {
    OnBootstrapSwitchFunctionCallbackName.invokeMethodAsync("OnSwitchChange", state)
}