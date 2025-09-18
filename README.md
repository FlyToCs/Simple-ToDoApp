# پروژه ToDo App (لیست کارها)

این یک پروژه‌ی ساده برای مدیریت کارهاست که با **C#** و کتابخانه‌ی **Dapper** نوشته شده.  

## امکانات
- اضافه کردن کار جدید ✅  
- نمایش لیست همه کارها 📋  
- ویرایش کار ✏️  
- حذف کار ❌  
- جستجو بر اساس شناسه (Id) 🔍  

## دیتابیس
- دیتابیس: **SQL Server**  
- جدول اصلی: `ToDoItems`  
- ستون‌ها:  
  - `Id` (کلید اصلی)  
  - `Title` (عنوان کار)  
  - `Description` (توضیحات)  
  - `IsDone` (انجام شده یا نه)

## نحوه اجرا
1. دیتابیس SQL Server را بسازید و جدول `ToDoItems` را ایجاد کنید.  
2. رشته‌ی اتصال (Connection String) را در فایل پروژه تنظیم کنید.  
3. پروژه را اجرا کنید.  
4. از طریق منوی متنی (Spectre.Console) می‌توانید کارها را مدیریت کنید.  

## پیش‌نیازها
- .NET 6 یا بالاتر  
- SQL Server  
- پکیج NuGet:  
  - `Dapper`  
  - `Spectre.Console`  

## اسکریپت ساخت جدول
```sql
CREATE TABLE ToDoItems (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX),
    IsDone BIT NOT NULL
);
