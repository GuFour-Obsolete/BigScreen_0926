
mergeInto(LibraryManager.library,
  {
    IAMREADY: function () {
      var WebGLReady = new CustomEvent("IAMREADY");
      if (window.dispatchEvent) {
        window.dispatchEvent(WebGLReady);
      } else {
        window.fireEvent(WebGLReady);
      }
    }
  });