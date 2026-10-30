using EduHub.Ch01.Domain;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("========================================");
Console.WriteLine("       ED UHUB - QUẢN LÝ CÂU LẠC BỘ");
Console.WriteLine("========================================");

// Bước 1: Tạo câu lạc bộ
Club club = Club.Create(
    "Tech Club",
    "Câu lạc bộ công nghệ thông tin");

Console.WriteLine("\n[1] TẠO CÂU LẠC BỘ");
Console.WriteLine($"Tên CLB: {club.Name}");
Console.WriteLine($"Mô tả: {club.Description}");

// Bước 2: Thêm 3 thành viên
Member member1 = Member.Create(
    "Nguyễn Văn An", "an@example.com", "SV001");

Member member2 = Member.Create(
    "Trần Thị Bình", "binh@example.com", "SV002");

Member member3 = Member.Create(
    "Lê Văn Cường", "cuong@example.com", "SV003");

club.AddMember(member1);
club.AddMember(member2);
club.AddMember(member3);

Console.WriteLine("\n[2] DANH SÁCH THÀNH VIÊN");

foreach (Member member in club.Members)
{
    Console.WriteLine(
        $"Mã SV: {member.StudentCode} | " +
        $"Họ tên: {member.Name} | Email: {member.Email}");
}

Console.WriteLine($"Tổng số thành viên: {club.MemberCount()}");

// Bước 3: Tạo sự kiện
Event event1 = Event.Create(
    club.Id,
    "Workshop AI",
    DateTime.Now.AddDays(7),
    50,
    false);

Console.WriteLine("\n[3] TẠO SỰ KIỆN");
Console.WriteLine($"Tên sự kiện: {event1.Title}");
Console.WriteLine($"Ngày tổ chức: {event1.Date:dd/MM/yyyy HH:mm}");
Console.WriteLine($"Sức chứa: {event1.Capacity}");
Console.WriteLine($"Hình thức: {(event1.IsOnline ? "Trực tuyến" : "Trực tiếp")}");

// Bước 4: Hai thành viên đăng ký và xác nhận
List<Registration> registrations = new();

Member[] participants = { member1, member2 };

Console.WriteLine("\n[4] ĐĂNG KÝ THAM DỰ");

foreach (Member member in participants)
{
    if (!event1.HasCapacity(registrations.Count))
    {
        Console.WriteLine("Sự kiện đã đủ chỗ.");
        break;
    }

    Registration registration =
        Registration.Create(member.Id, event1.Id);

    registrations.Add(registration);

    Console.WriteLine(
        $"{member.Name} đăng ký thành công. " +
        $"Trạng thái: {registration.Status}");

    registration.Confirm();

    Console.WriteLine(
        $"Xác nhận đăng ký: {registration.Status}");
}

// Bước 5: Một thành viên check-in
Console.WriteLine("\n[5] CHECK-IN SỰ KIỆN");

Registration selectedRegistration = registrations[0];

CheckIn checkIn = CheckIn.Create(
    selectedRegistration,
    "QR Code");

Console.WriteLine(checkIn.Summary());

// Bước 6: Báo cáo
Console.WriteLine("\n[6] BÁO CÁO THAM DỰ");
Console.WriteLine("----------------------------------------");
Console.WriteLine($"Tên CLB: {club.Name}");
Console.WriteLine($"Số thành viên CLB: {club.MemberCount()}");
Console.WriteLine($"Sự kiện: {event1.Title}");
Console.WriteLine($"Tổng đăng ký: {registrations.Count}");
Console.WriteLine(
    $"Đã xác nhận: {registrations.Count(r => r.Status == RegistrationStatus.Confirmed)}");
Console.WriteLine(
    $"Đã hủy: {registrations.Count(r => r.Status == RegistrationStatus.Cancelled)}");
Console.WriteLine("Số bản ghi check-in: 1");
Console.WriteLine("----------------------------------------");

Console.WriteLine("\nHoàn thành chương trình.");
