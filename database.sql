USE [master]
GO
/****** Object:  Database [BookStore]    Script Date: 5/13/2018 11:48:10 PM ******/
CREATE DATABASE [BookStore]
USE [BookStore]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 5/13/2018 11:48:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Book](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Code] [varchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[CoverPhoto] [nvarchar](250) NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[Quantity] [int] NULL,
	[Detail] [ntext] NULL,
	[BookAuthor] [bigint] NULL,
	[BookCategory] [bigint] NULL,
	[BookPublisher] [bigint] NULL,
	[TopHot] [bit] NULL,
	[New] [bit] NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BookAuthor]    Script Date: 5/13/2018 11:48:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookAuthor](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[PictureProfile] [nvarchar](250) NULL,
	[Address] [nvarchar](250) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[Story] [ntext] NULL,
 CONSTRAINT [PK_BookAuthor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BookCategory]    Script Date: 5/13/2018 11:48:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookCategory](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[ParentID] [bigint] NULL,
	[DisplayOrder] [int] NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_BookCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BookPublishers]    Script Date: 5/13/2018 11:48:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookPublishers](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Address] [nvarchar](250) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
 CONSTRAINT [PK_BookPublishers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 5/13/2018 11:48:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [bigint] NOT NULL,
	[Paid] [bit] NULL,
	[DeliveryAddress] [nvarchar](250) NULL,
	[DeliveryStatus] [nvarchar](50) NULL,
	[OrderDate] [datetime] NULL,
	[DeliveryDate] [datetime] NULL,
	[UserID] [bigint] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 5/13/2018 11:48:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderID] [bigint] NOT NULL,
	[BookID] [bigint] NOT NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](18, 0) NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Slide]    Script Date: 5/13/2018 11:48:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slide](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Link] [nvarchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Slide] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/13/2018 11:48:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Role] [nvarchar](50) NULL DEFAULT (N'Người dùng'),
	[Name] [nvarchar](250) NULL,
	[Address] [nvarchar](250) NULL,
	[Gender] [nvarchar](50) NULL DEFAULT (N'Nữ'),
	[Email] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[Status] [bit] NOT NULL CONSTRAINT [DF_Users_Status]  DEFAULT ((1)),
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (5, N'Cô Gái Trên Tàu', N'SS01', N'Cô gái trên tàu', N'/Assets/Images/images/cogaitrentau.jpg', CAST(69300 AS Decimal(18, 0)), 499, N'Cô Gái Trên Tàu

Rachel mỗi ngày đều đón cùng một chuyến tàu điện. Mỗi ngày như thế, con tàu dừng lại ở một ga nhỏ, từ cửa sổ cô có thể nhìn thấy một cặp vợ chồng ngồi ăn sáng trên ban công. Dần dần, cô cảm thấy mình quen với họ.

Và rồi một ngày kia, cô nhìn thấy một chuyện kinh hoàng. Chuyện chỉ xảy ra trong một phút rồi con tàu lại cất bánh đi tiếp, nhưng như thế cũng đủ rồi. Rachel không thể im lặng, cô phải nói cho cảnh sát biết những gì mình nhìn thấy và bị cuốn vào vòng xoáy của mọi việc. Liệu cô đã làm một việc tốt hay đã khiến mọi thứ rối rắm hơn?', 5, 1, 1, 1, 0, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (8, N'1', N'SachVV', N'123', N'/Assets/Images/images/000012.jpg', CAST(123 AS Decimal(18, 0)), 1, N'123', 2, 1, 1, 0, 0, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (9, N'Nếu chỉ còn một ngày để sống', N'MS01', N'Nếu chỉ còn một ngày để sống', N'/Assets/Images/images/000010.jpg', CAST(78000 AS Decimal(18, 0)), 1000, N'Nếu chỉ còn một ngày để sốngNếu chỉ còn một ngày để sốngNếu chỉ còn một ngày để sốngNếu chỉ còn một ngày để sốngNếu chỉ còn một ngày để sống
Nếu chỉ còn một ngày để sốngNếu chỉ còn một ngày để sốngNếu chỉ còn một ngày để sốngNếu chỉ còn một ngày để sống
Nếu chỉ còn một ngày để sốngNếu chỉ còn một ngày để sốngNếu chỉ còn một ngày để sống', 5, 3, 1, 0, 0, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (10, N'Đời ngắn đừng ngủ dài', N'MS02', N'Đời ngắn đừng ngủ dài', N'/Assets/Images/images/000009.jpg', CAST(56000 AS Decimal(18, 0)), 200, N'Đời ngắn đừng ngủ dàiĐời ngắn đừng ngủ dàiĐời ngắn đừng ngủ dàiĐời ngắn đừng ngủ dàiĐời ngắn đừng ngủ dàiĐời ngắn đừng ngủ dàiĐời ngắn đừng ngủ dàiĐời ngắn đừng ngủ dàiĐời ngắn đừng ngủ dàiĐời ngắn đừng ngủ dàiĐời ngắn đừng ngủ dài', 2, 1, 1, 0, 0, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (11, N'S1', N'123', N'123121', N'/Assets/Images/images/000007.jpg', CAST(123123 AS Decimal(18, 0)), 700, N'123121123121123121123121123121', 2, 1, 1, 1, 0, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (12, N'S2', N's2', N'76000g ', N'/Assets/Images/images/000001.jpg', CAST(76000 AS Decimal(18, 0)), 500, N'aabcc
c
c
a

ca
c
a', 5, 4, 1, 1, 0, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (13, N'S3', N'S3', N'S3S3S3S3S3S3', N'/Assets/Images/images/000005.jpg', CAST(56000 AS Decimal(18, 0)), 400, N'S3S3S3S3S3S3S3S3S3S3S3S3S3S3S3S3S3S3S3S3S3S3S3S3S3S3S3S3S3', 2, 1, 1, 1, 0, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (14, N'S4', N'S4', N'123123123', N'/Assets/Images/images/000006.jpg', CAST(1231 AS Decimal(18, 0)), 1231, N'12312312312', 2, 1, 1, 1, 0, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (15, N'N1', N'n1', N'123213', N'/Assets/Images/images/000003.jpg', CAST(1231 AS Decimal(18, 0)), 13213, N'123123123', 2, 1, 1, 0, 1, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (16, N'N2', N'123', N'3123412', N'/Assets/Images/images/000004.jpg', CAST(1231 AS Decimal(18, 0)), 321, N'13213123', 5, 2, 1, 0, 1, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (17, N'N3', N'n3', N'333333', N'/Assets/Images/images/000002.jpg', CAST(33333 AS Decimal(18, 0)), 3333, N'333333', 5, 2, 1, 0, 1, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (18, N'N4', N'n4', N'123331', N'/Assets/Images/images/000001.jpg', CAST(123 AS Decimal(18, 0)), 123, N'13123121312312131231213123121312312131231213123121312312131231213123121312312131231213123121312312131231213123121312312131231213123121312312131231213123121312312', 2, 1, 1, 0, 1, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (19, N'n5', N'123', N'3214123', N'/Assets/Images/images/000028.jpg', CAST(31213 AS Decimal(18, 0)), 1222, N'123123123123121231231231231212312312312312123123123123121231231231231212312312312312', 2, 1, 1, 0, 1, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (20, N'Nếu không phải một giấc mơ', N'SS02', N'Nếu không phải một giấc mơ', N'/Assets/Images/images/000001.jpg', CAST(75000 AS Decimal(18, 0)), 300, N'Lauren là nữ bác sĩ làm việc chăm chỉ trong một phòng cấp cứu bệnh viện thành phố  nhưng không may bị tai nạn. Được các đồng nghiệp cấp cứu nhưng cô khó có thể thoát khỏi bàn tay tử thần đang rình rập. Cô được chuyển đến bệnh viện và được chăm sóc ở đấy như một người thực vật, không hề nhận biết được gì đang xảy ra xung quanh và đợi cái chết có thể đến bất cứ lúc nào. Chuyện về tai nạn giao thông thảm khốc này cuối cùng cũng lắng xuống sau một thời gian.', 6, 3, 1, 0, 0, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (21, N'Gặp lại', N'SS03', N'Gặp lại', N'/Assets/Images/images/GapLai.jpg', CAST(68000 AS Decimal(18, 0)), 300, N'Nếu cuộc đời có khi nào mang lại cho Arthur và Lauren một cơ may thứ hai để gặp lại, liệu họ có bất chấp mọi hiểm nguy để nắm bắt lấy nó? Marc Levy đã trở lại với những nhân vật trong tiểu thuyết đầu tay "Nếu em không phải một giấc mơ"... trong một Gặp lại hài hước và lãng mạn, dẫn dắt độc giả vào một chuyến phiêu lưu chưa từng có, thấm đẫm cảm xúc, bằng một giọng điệu hóm hỉnh và vô số những tình tiết bất ngờ nối tiếp...', 6, 3, 3, 0, 0, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (22, N'Hoa Linh Lan', N'SS04', N'Hoa linh lan', N'/Assets/Images/images/000001.jpg', CAST(72000 AS Decimal(18, 0)), 190, N'"Tôi đã từng rất hoang mang với thời đại của mình. Thời đại của những con người cô đơn được giấu trong hình hài nhỏ bé. Thời đại huyên náo của đám đông, đầy ắp những cá nhân lặng lẽ. À, cô đơn, hóa ra ai cũng đã từng có cái cảm giác buồn cười như thế: Một mình giữa mọi người. Hoa Linh Lan được viết vào đầu năm 2008, khi cảm giác lúng túng tìm lối ra trong thời đại ấy, kiểm soát tâm trí tôi - một cô gái ngày ấy mới bước vào tuổi hai mươi, chưa biết làm chủ cuộc đời mình thế nào mới đúng?', 7, 2, 3, 0, 0, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (23, N'Mẹ, em bé và bố', N'SS05', N'Mẹ, em bé và bố', N'/Assets/Images/images/meembevabo.jpg', CAST(89000 AS Decimal(18, 0)), 350, NULL, 7, 2, 4, 1, 1, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (24, N'Chí phèo', N'SS06', N'Chí phèo', N'/Assets/Images/images/chipheo.jpg', CAST(70000 AS Decimal(18, 0)), 150, N'Chí Phèo – Với những tình tiết hấp hẫn Nam Cao đã đưa người đọc tái hiện bức tranh chân thực nông thôn Việt Nam trước 1945, nghèo đói, xơ xác trên con đường phá sản, bần cùng, hết sức thê thảm, người nông dân bị đẩy vào con đường tha hóa, lưu manh hóa.', 2, 2, 5, 0, 1, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (25, N'Đoạn đường để nhớ', N'SS07', N'Đoạn đường để nhớ', N'/Assets/Images/images/doanduongdenho.jpg', CAST(62000 AS Decimal(18, 0)), 250, N'Thị trấn ven biển Beaufort, nơi từ tháng Tư chí tháng Mười trẻ con chạy chân trần trên phố, nơi người ta vui vẻ chào nhau từ cửa kính ô tô dù có quen biết hay không. Khi vội vàng lướt qua cuốn kỷ yếu để tìm bạn nhảy tạm cho vũ hội đầu năm, Landon không ngờ rằng cô gái rụt rè và mờ nhạt cậu chọn sẽ lột xác thành thiên thần xinh đẹp trong ngày công diễn vở kịch Giáng sinh. Nhưng chính vẻ đẹp đích thực trong tâm hồn Jamie mà Landon ngỡ ngàng nhận ra sau những buổi tập kịch, những lần tản bộ về nhà và trò chuyện bên hàng hiên mới dần khiến cậu phải lòng cô. Landon và Jamie say sưa trong hương vị ngọt ngào của tình yêu đầu đời, nhưng chờ đợi phía trước họ là một bí mật chưa kể sẽ khiến cuộc đời họ vĩnh viễn thay đổi.', 8, 3, 3, 1, 0, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (26, N'John yêu dấu', N'SS08', N'John yêu dấu', N'/Assets/Images/images/johnyeudau.jpg', CAST(82000 AS Decimal(18, 0)), 300, N'John Tyree, một quân nhân có thời niên thiếu nổi loạn về nghỉ phép ở quê nhà Bắc Carolina, nơi mà trong tâm khảm, anh chưa bao giờ cảm thấy gắn bó. Savannah Lynn Curtis, một cô sinh viên mẫu mực đến Bắc Carolina làm từ thiện nhân dịp hè. Hai tính cách đối lập ấy đến với nhau như định mệnh, vào một ngày nắng vàng trên bãi biển cát trắng…', 8, 3, 5, 0, 1, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (27, N'The Notebook', N'SS09', N'The Notebook', N'/Assets/Images/images/thenotebook.jpg', CAST(188000 AS Decimal(18, 0)), 400, N'Every so often a love story so captures our hearts that it becomes more than a story-it becomes an experience to remember forever. The Notebook is such a book. It is a celebration of how passion can be ageless and timeless, a tale that moves us to laughter and tears and makes us believe in true love all over again...', 8, 3, 4, 0, 0, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (28, N'Mắt biếc', N'SS10', N'Mắt biếc', N'/Assets/Images/images/matbiec.jpg', CAST(58000 AS Decimal(18, 0)), 100, N'Một tác phẩm được nhiều người bình chọn là hay nhất của nhà văn này. Một tác phẩm đang được dịch và giới thiệu tại Nhật Bản (theo thông tin từ các báo)… Bởi sự trong sáng của một tình cảm, bởi cái kết thúc rất, rất buồn khi suốt câu chuyện vẫn là những điều vui, buồn lẫn lộn (cái kết thúc không như mong đợi của mọi người). Cũng bởi, mắt biếc… năm xưa nay đâu (theo lời một bài hát).', 9, 2, 6, 1, 0, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (29, N'Hoa vàng trên cỏ xanh', N'SS11', N'Tôi thấy hoa vàng trên cỏ xanh', N'/Assets/Images/images/toithayhoavangtrencoxanh.jpg', CAST(82000 AS Decimal(18, 0)), 200, N'Ta bắt gặp trong Tôi Thấy Hoa Vàng Trên Cỏ Xanh một thế giới đấy bất ngờ và thi vị non trẻ với những suy ngẫm giản dị thôi nhưng gần gũi đến lạ. Câu chuyện của Tôi Thấy Hoa Vàng Trên Cỏ Xanh có chút này chút kia, để ai soi vào cũng thấy mình trong đó, kiểu như lá thư tình đầu đời của cu Thiều chẳng hạn... ngây ngô và khờ khạo.', 9, 2, 6, 1, 1, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (30, N'Chúc một ngày tốt lành', N'SS12', N'Chúc một ngày tốt lành', N'/Assets/Images/images/chucmotngaytotlanh.jpg', CAST(99000 AS Decimal(18, 0)), 250, N'Đọc tựa cuốn sách mới nhất của nhà văn Nguyễn Nhật Ánh là muốn mở ngay trang sách. Bạn sẽ thấy một thứ ngôn ngữ lạ của Hàn Quốc hay của nước nào tùy bạn đoán,  Gô un un là Chào buổi sáng; Un gô gô là Chúc ngủ ngon, và nữa, Chiếp un un; Ăng gô gô; Chiếp chiếp gô…', 9, 2, 6, 0, 0, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (31, N'Khi lỗi thuộc về những vì sao', N'SS13', N'Khi lỗi thuộc về những vì sao', N'/Assets/Images/images/khiloithuocvenhungvisao.jpg', CAST(105000 AS Decimal(18, 0)), 200, N'Mặc dù phép màu y học đã giúp thu hẹp khối u và ban thêm vài năm sống cho Hazel nhưng cuộc đời cô bé đang ở vào giai đoạn cuối, từng chương kế tiếp được viết theo kết quả chẩn đoán. Nhưng khi có một nhân vật điển trai tên là Augustus Waters đột nhiên xuất hiện tại Hội Tương Trợ Bệnh Nhi Ung Thư, câu chuyện của Hazel sắp được viết lại hoàn toàn.', 10, 3, 6, 1, 0, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (32, N'Chuyện chàng nàng', N'SS14', N'Chuyện chàng nàng', N'/Assets/Images/images/chuyenchangnang.jpg', CAST(86000 AS Decimal(18, 0)), 300, N'Một trang web kết bạn bốn phương đã đưa chàng và nàng đến với nhau. Họ không trở thành người yêu, mà là bạn bè của nhau. Và cả hai đều chỉ muốn dừng lại ở đó...', 6, 3, 1, 0, 0, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (33, N'Nếu như được làm lại', N'SS15', N'Nếu như được làm lại', N'/Assets/Images/images/neunhuduoclamlai.jpg', CAST(92000 AS Decimal(18, 0)), 400, N'Andrew Stilman, nhà báo nổi tiếng của tờ The New York Times, vừa kết hôn.

Sáng ngày 9 tháng Bảy 2012, anh đột ngột bị tấn công khi đang chạy bộ dọc sông Hudson. Anh gục ngã trong vũng máu…

Andrew tỉnh lại vào ngày 9 tháng Năm 2012, hai tháng trước lễ cưới.

Kể từ giờ phút đó, anh có 60 ngày để tìm ra kẻ giết mình, 60 ngày giằng co với số phận.', 6, 3, 5, 1, 1, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (34, N'Tôi là một thành phố', N'SS16', N'Tôi là một thành phố', N'/Assets/Images/images/toilamotthanhpho.jpg', CAST(69000 AS Decimal(18, 0)), 150, N'"Tôi là một thành phố, có những khủng hoảng, có những tiêu cực, nhưng không đến với cuộc đời này để bị dẹp bỏ đi. Chẳng thành phố nào được xây dựng để bị người ta phá hủy, nó hình thành để ngày một mạnh hơn, phát triển hơn, tươi đẹp hơn. Thành phố vẫn có những con người ngày đêm vất vả, mặt mũi lấm lem không thấy ánh mặt trời, tay xách nặng, miệng ngân nga. Họ vẫn hát trên những nhọc nhằn mồ hôi và nước mắt.Tôi có những lúc mệt mỏi, gục ngã và tổn thương, thất vọng và nhọc nhằn nhưng vẫn ôm trong tim những khát khao tươi trẻ nhất, dùng lực hút của hoài bão mà đứng lên tiến về phía trước.', 11, 2, 5, 1, 0, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (35, N'Mình là cá', N'SS17', N'Mình là cá, việc của mình là bơi', N'/Assets/Images/images/minhlacavieccuaminhlaboi.jpg', CAST(89000 AS Decimal(18, 0)), 250, N'ãy tập trung vào việc mình có thể làm được và làm tốt công việc ấy. Cuộc đời không bao giờ cho chúng ta những thử thách mà con người không thể vượt qua được. Trái tim con người vốn là tạo vật mạnh mẽ nhất, chỉ cần bạn luôn ghi nhớ điều đó.', 12, 3, 4, 0, 0, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (36, N'Tương lai tươi sáng', N'SS18', N'Đừng để tương lai ghét bạn hiện tại', N'/Assets/Images/images/dungdetuonglaighetbanhientai.jpg', CAST(96000 AS Decimal(18, 0)), 200, N'ã bao giờ bạn tự hỏi bản thân mình rằng, bạn đang sống thế nào? Điều bạn thực sự đang cần lúc này là gì không?

Đã bao giờ bạn nghĩ đến những việc bạn đang và sẽ làm ở hiện tại sẽ mang đến kết quả như thế nào ở tương lai không?

Rất nhiều những câu hỏi không tên, những hoang mang, sẽ xuất hiện trong cuộc đời của bạn khi bạn bước vào ngưỡng cửa trưởng thành. Nhưng xin đừng lo lắng, cuốn sách này sẽ như một người bạn tâm giao mà bạn có thể tin tưởng và đặt lòng tin vào nó. ', 12, 3, 7, 1, 1, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (37, N'Hạnh phúc là thứ dễ lây lan', N'SS19', N'Hạnh phúc là thứ dễ lây lan', N'/Assets/Images/images/hanhphuclathudelaylan.jpg', CAST(78000 AS Decimal(18, 0)), 300, N'Hạnh Phúc Là Thứ Dễ Lây Lan được hàng trăm nghìn kỳ vọng, chờ đợi từ các độc giả của nhiều Fanpage lớn từ cuối năm 2013 và những ngày đầu năm 2014 này. Bởi không chỉ nó là sự kết hợp từ 3 tên tuổi đang được yêu thích nhất mà nó còn là bởi ai cũng mong được nhâm nhi Hạnh Phúc. Mỗi bài viết, mỗi bức tranh đều hướng đến cảm xúc tích cực nhất của con người, ham muốn lớn nhất của con người: Hạnh Phúc.', 13, 2, 5, 0, 1, 1)
INSERT [dbo].[Book] ([ID], [Name], [Code], [Description], [CoverPhoto], [Price], [Quantity], [Detail], [BookAuthor], [BookCategory], [BookPublisher], [TopHot], [New], [Status]) VALUES (38, N'Hết hôm nay là đến hôm qua', N'SS20', N'Hết hôm nay là đến hôm qua', N'/Assets/Images/images/000052.jpg', CAST(20000 AS Decimal(18, 0)), 100, N'Nếu bạn đã từng là một trong số rất nhiều fan hâm mộ của anh Chánh Văn hóm hỉnh, tâm lý; nếu bạn đã từng thích thú bộ phim đầu tiên dành cho tuổi teen “Chiến dịch trái tim bên phải” thì chắc hẳn các bạn sẽ không thể bỏ qua “Hết hôm nay là đến hôm qua” – tác phẩm mới nhất của cây bút Hoàng Anh Tú, hứa hẹn sẽ đem đến những câu chuyện mà bạn phải thốt lên “Chỉ có thể là tuổi trẻ!”', 13, 2, 5, 1, 0, 1)
SET IDENTITY_INSERT [dbo].[Book] OFF
SET IDENTITY_INSERT [dbo].[BookAuthor] ON 

INSERT [dbo].[BookAuthor] ([ID], [Name], [PictureProfile], [Address], [PhoneNumber], [Story]) VALUES (2, N'Nam Cao', N'/Assets/Images/images/1.jpg', N'Hà Nội', N'111', N'Nam Cao (1915/1917- 28 tháng 11 năm 1951) là một nhà văn người Việt Nam. Ông là nhà văn hiện thực lớn (trước Cách mạng), một nhà báo kháng chiến (sau Cách mạng), một trong những nhà văn tiêu biểu nhất thế kỷ 20. Nam Cao có nhiều đóng góp quan trọng đối với việc hoàn thiện phong cách truyện ngắn và tiểu thuyết Việt Nam ở nửa đầu thế kỷ 20.')
INSERT [dbo].[BookAuthor] ([ID], [Name], [PictureProfile], [Address], [PhoneNumber], [Story]) VALUES (5, N'Paula Hawskin', N'/Assets/Images/images/2.jpg', N'England', N'123123', N'bc')
INSERT [dbo].[BookAuthor] ([ID], [Name], [PictureProfile], [Address], [PhoneNumber], [Story]) VALUES (6, N'Marc Levy', N'/Assets/Images/images/marclevy.jpg', N'France', N'222', N'abc')
INSERT [dbo].[BookAuthor] ([ID], [Name], [PictureProfile], [Address], [PhoneNumber], [Story]) VALUES (7, N'Gào', N'/Assets/Images/images/gao.jpg', N'Hà Nội', N'333', N'cde')
INSERT [dbo].[BookAuthor] ([ID], [Name], [PictureProfile], [Address], [PhoneNumber], [Story]) VALUES (8, N'Nicholas Sparks', N'/Assets/Images/images/nicholassparks.jpg', N'USA', N'444', N'bef')
INSERT [dbo].[BookAuthor] ([ID], [Name], [PictureProfile], [Address], [PhoneNumber], [Story]) VALUES (9, N'Nguyễn Nhật Ánh', N'/Assets/Images/images/nguyennhatanh.jpg', N'Tp Hồ Chí Minh', N'555', N'cvb')
INSERT [dbo].[BookAuthor] ([ID], [Name], [PictureProfile], [Address], [PhoneNumber], [Story]) VALUES (10, N'John Green', N'/Assets/Images/images/johngreen.jpg', N'USA', N'666', N'ghj')
INSERT [dbo].[BookAuthor] ([ID], [Name], [PictureProfile], [Address], [PhoneNumber], [Story]) VALUES (11, N'Phạm Anh Thư', N'/Assets/Images/images/phamanhthu.jpg', N'Cần thơ', N'777', N'iop')
INSERT [dbo].[BookAuthor] ([ID], [Name], [PictureProfile], [Address], [PhoneNumber], [Story]) VALUES (12, N'Takeshi Furukawa', N'/Assets/Images/images/takeshifurukawa.jpg', N'Japan', N'888', N'uip')
INSERT [dbo].[BookAuthor] ([ID], [Name], [PictureProfile], [Address], [PhoneNumber], [Story]) VALUES (13, N'Hoàng Anh Tú', N'/Assets/Images/images/hoanganhtu.jpg', N'Tp Hồ Chí Minh', N'999', N'yui')
SET IDENTITY_INSERT [dbo].[BookAuthor] OFF
SET IDENTITY_INSERT [dbo].[BookCategory] ON 

INSERT [dbo].[BookCategory] ([ID], [Name], [ParentID], [DisplayOrder], [Status]) VALUES (1, N'Văn học', NULL, 1, 1)
INSERT [dbo].[BookCategory] ([ID], [Name], [ParentID], [DisplayOrder], [Status]) VALUES (2, N'Văn học trong nước', 1, 2, 1)
INSERT [dbo].[BookCategory] ([ID], [Name], [ParentID], [DisplayOrder], [Status]) VALUES (3, N'Văn học nước ngoài', 1, 2, 1)
INSERT [dbo].[BookCategory] ([ID], [Name], [ParentID], [DisplayOrder], [Status]) VALUES (4, N'1', NULL, 1, 1)
SET IDENTITY_INSERT [dbo].[BookCategory] OFF
SET IDENTITY_INSERT [dbo].[BookPublishers] ON 

INSERT [dbo].[BookPublishers] ([ID], [Name], [Address], [PhoneNumber]) VALUES (1, N'NXB Kim Đồng', N'Hà Nội', N'12324578')
INSERT [dbo].[BookPublishers] ([ID], [Name], [Address], [PhoneNumber]) VALUES (3, N'NXB Hội Nhà Văn', N'Hà Nội', N'13579135')
INSERT [dbo].[BookPublishers] ([ID], [Name], [Address], [PhoneNumber]) VALUES (4, N'NXB Phụ Nữ', N'Hà Nội', N'11111111')
INSERT [dbo].[BookPublishers] ([ID], [Name], [Address], [PhoneNumber]) VALUES (5, N'NXB Thế Giới', N'Hà Nội', N'22222222')
INSERT [dbo].[BookPublishers] ([ID], [Name], [Address], [PhoneNumber]) VALUES (6, N'NXB Văn học', N'Đà Nẵng', N'33333333')
INSERT [dbo].[BookPublishers] ([ID], [Name], [Address], [PhoneNumber]) VALUES (7, N'NXB Trẻ', N'Hải Phòng', N'44444444')
INSERT [dbo].[BookPublishers] ([ID], [Name], [Address], [PhoneNumber]) VALUES (8, N'NXB Thanh niên', N'Cần thơ', N'55555555')
SET IDENTITY_INSERT [dbo].[BookPublishers] OFF
INSERT [dbo].[Order] ([ID], [Paid], [DeliveryAddress], [DeliveryStatus], [OrderDate], [DeliveryDate], [UserID]) VALUES (1, 0, N'Hà nội', N'Chưa giao hàng', CAST(N'2018-04-12 00:00:00.000' AS DateTime), CAST(N'2018-04-20 00:00:00.000' AS DateTime), 3)
INSERT [dbo].[Order] ([ID], [Paid], [DeliveryAddress], [DeliveryStatus], [OrderDate], [DeliveryDate], [UserID]) VALUES (2, 1, N'HCM', N'Đã giao hàng', CAST(N'2018-03-12 00:00:00.000' AS DateTime), CAST(N'2018-03-23 00:00:00.000' AS DateTime), 3)
INSERT [dbo].[Order] ([ID], [Paid], [DeliveryAddress], [DeliveryStatus], [OrderDate], [DeliveryDate], [UserID]) VALUES (3, 1, N'Hà Nội', N'Đã giao hàng', CAST(N'2018-04-01 00:00:00.000' AS DateTime), CAST(N'2018-04-08 00:00:00.000' AS DateTime), 3)
INSERT [dbo].[Order] ([ID], [Paid], [DeliveryAddress], [DeliveryStatus], [OrderDate], [DeliveryDate], [UserID]) VALUES (4, 0, N'Đà nẵng', N'Chưa giao hàng', CAST(N'2018-03-13 00:00:00.000' AS DateTime), CAST(N'2018-04-13 00:00:00.000' AS DateTime), 9)
INSERT [dbo].[Order] ([ID], [Paid], [DeliveryAddress], [DeliveryStatus], [OrderDate], [DeliveryDate], [UserID]) VALUES (5, 1, N'Cần thơ', N'Đã giao hàng', CAST(N'2018-03-17 00:00:00.000' AS DateTime), CAST(N'2018-03-17 00:00:00.000' AS DateTime), 10)
INSERT [dbo].[Order] ([ID], [Paid], [DeliveryAddress], [DeliveryStatus], [OrderDate], [DeliveryDate], [UserID]) VALUES (6, 1, N'Tuyên Quang', N'Đã giao hàng', CAST(N'2018-03-06 00:00:00.000' AS DateTime), CAST(N'2018-03-10 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Order] ([ID], [Paid], [DeliveryAddress], [DeliveryStatus], [OrderDate], [DeliveryDate], [UserID]) VALUES (7, 1, N'Quảng ninh', N'Chưa giao hàng', CAST(N'2018-03-18 00:00:00.000' AS DateTime), CAST(N'2018-04-23 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Order] ([ID], [Paid], [DeliveryAddress], [DeliveryStatus], [OrderDate], [DeliveryDate], [UserID]) VALUES (8, 1, N'Hải phòng', N'Chưa giao hàng', CAST(N'2018-03-15 00:00:00.000' AS DateTime), CAST(N'2018-06-17 00:00:00.000' AS DateTime), 11)
INSERT [dbo].[Order] ([ID], [Paid], [DeliveryAddress], [DeliveryStatus], [OrderDate], [DeliveryDate], [UserID]) VALUES (9, 0, N'HCM', N'Chưa giao hàng', CAST(N'2018-03-19 00:00:00.000' AS DateTime), CAST(N'2018-05-13 00:00:00.000' AS DateTime), 12)
INSERT [dbo].[Order] ([ID], [Paid], [DeliveryAddress], [DeliveryStatus], [OrderDate], [DeliveryDate], [UserID]) VALUES (10, 0, N'Đà nẵng', N'Chưa giao hàng', CAST(N'2018-04-13 00:00:00.000' AS DateTime), CAST(N'2018-07-13 00:00:00.000' AS DateTime), 12)
INSERT [dbo].[OrderDetail] ([OrderID], [BookID], [Quantity], [Price]) VALUES (1, 5, 1, CAST(69300 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([OrderID], [BookID], [Quantity], [Price]) VALUES (1, 8, 2, CAST(246 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([OrderID], [BookID], [Quantity], [Price]) VALUES (2, 5, 1, CAST(69300 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([OrderID], [BookID], [Quantity], [Price]) VALUES (3, 8, 2, CAST(246 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([OrderID], [BookID], [Quantity], [Price]) VALUES (4, 25, 1, CAST(62000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([OrderID], [BookID], [Quantity], [Price]) VALUES (5, 32, 2, CAST(86000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([OrderID], [BookID], [Quantity], [Price]) VALUES (6, 34, 3, CAST(69000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([OrderID], [BookID], [Quantity], [Price]) VALUES (7, 35, 1, CAST(89000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([OrderID], [BookID], [Quantity], [Price]) VALUES (8, 36, 4, CAST(96000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([OrderID], [BookID], [Quantity], [Price]) VALUES (9, 31, 5, CAST(105000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([OrderID], [BookID], [Quantity], [Price]) VALUES (10, 27, 1, CAST(188000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Slide] ON 

INSERT [dbo].[Slide] ([ID], [Name], [Link], [Status]) VALUES (2, N'slide1', N'/Assets/Images/images/slide1.jpg', 1)
INSERT [dbo].[Slide] ([ID], [Name], [Link], [Status]) VALUES (4, N'slide2', N'/Assets/Images/images/slide2.jpg', 1)
INSERT [dbo].[Slide] ([ID], [Name], [Link], [Status]) VALUES (6, N'slide3', N'/Assets/Images/images/slide3.png', 1)
INSERT [dbo].[Slide] ([ID], [Name], [Link], [Status]) VALUES (8, N'slide 5', N'/Assets/Images/images/slide3.png', 0)
SET IDENTITY_INSERT [dbo].[Slide] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Username], [Password], [Role], [Name], [Address], [Gender], [Email], [PhoneNumber], [Status]) VALUES (1, N'samy', N'202cb962ac59075b964b07152d234b70', N'Admin', N'Samy Kyu', N'Hà Nội', N'Nữ', N'samy@gmail.com', N'097665', 1)
INSERT [dbo].[Users] ([ID], [Username], [Password], [Role], [Name], [Address], [Gender], [Email], [PhoneNumber], [Status]) VALUES (2, N'sanero', N'202cb962ac59075b964b07152d234b70', N'Admin', N'Sanero', N'Hà Nội', N'Nam', N'sanero@gmail.com', N'012121211', 1)
INSERT [dbo].[Users] ([ID], [Username], [Password], [Role], [Name], [Address], [Gender], [Email], [PhoneNumber], [Status]) VALUES (3, N'1', N'c4ca4238a0b923820dcc509a6f75849b', N'Người dùng', N'2', N'1', N'Nam', N'1', N'1', 1)
INSERT [dbo].[Users] ([ID], [Username], [Password], [Role], [Name], [Address], [Gender], [Email], [PhoneNumber], [Status]) VALUES (7, N'fufu', N'c4ca4238a0b923820dcc509a6f75849b', N'Người dùng', N'1', N'1', N'1', N'1', N'1', 1)
INSERT [dbo].[Users] ([ID], [Username], [Password], [Role], [Name], [Address], [Gender], [Email], [PhoneNumber], [Status]) VALUES (8, N'2', N'c81e728d9d4c2f636f067f89cc14862c', N'Người dùng', N'2', N'2', N'2', N'2', N'2', 1)
INSERT [dbo].[Users] ([ID], [Username], [Password], [Role], [Name], [Address], [Gender], [Email], [PhoneNumber], [Status]) VALUES (9, N'abc', N'c4ca4238a0b923820dcc509a6f75849b', N'Người dùng', N'abc', N'Tp HCM', N'Nam', N'abc@gmail.com', N'111111', 1)
INSERT [dbo].[Users] ([ID], [Username], [Password], [Role], [Name], [Address], [Gender], [Email], [PhoneNumber], [Status]) VALUES (10, N'def', N'c4ca4238a0b923820dcc509a6f75849b', N'Người dùng', NULL, NULL, N'Nữ', NULL, NULL, 1)
INSERT [dbo].[Users] ([ID], [Username], [Password], [Role], [Name], [Address], [Gender], [Email], [PhoneNumber], [Status]) VALUES (11, N'ghi', N'c4ca4238a0b923820dcc509a6f75849b', N'Người dùng', N'ghi', N'Đà nẵng', N'Nữ', N'ghi@gmail.com', N'222222', 1)
INSERT [dbo].[Users] ([ID], [Username], [Password], [Role], [Name], [Address], [Gender], [Email], [PhoneNumber], [Status]) VALUES (12, N'klm', N'c4ca4238a0b923820dcc509a6f75849b', N'Người dùng', N'klm', N'Lào cai', N'Nam', N'klm@gmail.com', N'888888', 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
USE [master]
GO
ALTER DATABASE [BookStore] SET  READ_WRITE 
GO
