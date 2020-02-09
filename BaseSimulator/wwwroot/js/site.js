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

var OnCarouselSlidCallbackName;
function SetSlidCarousel(elem, funcCallback) {
    $(elem).off("slid.bs.carousel", OnCarouselSlid);
    $(elem).on("slid.bs.carousel", OnCarouselSlid);

    OnCarouselSlidCallbackName = funcCallback;
}

function OnCarouselSlid(e) {
    OnCarouselSlidCallbackName.invokeMethodAsync("OnCarouselSlid", e.to)
}