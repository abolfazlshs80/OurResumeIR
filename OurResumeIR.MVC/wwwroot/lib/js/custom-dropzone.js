Dropzone.options.myDropzone = {
    paramName: "file", // نام پارامتری که در سمت سرور استفاده می‌شود
    maxFilesize: 10, // حداکثر اندازه فایل (برحسب MB)
    maxFiles: 1,
    acceptedFiles: ".jpeg,.jpg,.png,.gif", // نوع فایل‌های مجاز
    init: function () {
        this.on("success", function (file, response) {
            console.log("فایل آپلود شد:", response);
            alert(response.message); // نمایش پیام موفقیت
        });
        // رویداد Maxfilesexceeded برای محدود کردن تعداد فایل‌ها
        this.on("maxfilesexceeded", function (file) {
            alert("فقط می‌توانید یک فایل آپلود کنید.");
            this.removeFile(file); // حذف فایل اضافی
        });

        this.on("error", function (file, response) {
            console.error("خطا در آپلود فایل:", response);
            alert("خطا: " + response.message);
        });

    }
};