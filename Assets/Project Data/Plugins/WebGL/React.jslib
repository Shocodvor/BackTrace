mergeInto(LibraryManager.library, {
  AppStarted: function () {
    window.dispatchReactUnityEvent("AppStarted");
  },
  OnClaimReward: function () {   
    window.dispatchReactUnityEvent("OnClaimReward");
  }
}); 