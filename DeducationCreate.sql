USE [DeducationDB13]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 12/12/2023 1:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [uniqueidentifier] NOT NULL,
	[UniversityId] [uniqueidentifier] NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Credits] [int] NOT NULL,
	[Instructor] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employers]    Script Date: 12/12/2023 1:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employers](
	[Id] [uniqueidentifier] NOT NULL,
	[CompanyName] [nvarchar](max) NOT NULL,
	[ContactPersonName] [nvarchar](max) NOT NULL,
	[ContactPersonPhone] [nvarchar](max) NOT NULL,
	[ContactPersonEmail] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Country] [nvarchar](max) NOT NULL,
	[Since] [int] NOT NULL,
	[CompanyIndustry] [nvarchar](max) NOT NULL,
	[LinkToProfile] [nvarchar](max) NOT NULL,
	[CompanyDescription] [nvarchar](max) NOT NULL,
	[CompanyLocation] [nvarchar](max) NOT NULL,
	[JobTypes] [nvarchar](max) NOT NULL,
	[ImageUrl] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Employers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Professors]    Script Date: 12/12/2023 1:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professors](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Country] [nvarchar](max) NOT NULL,
	[FieldOfStudy] [nvarchar](max) NOT NULL,
	[Degree] [nvarchar](max) NOT NULL,
	[YearGraduated] [datetime2](7) NOT NULL,
	[CurrentPosition] [nvarchar](max) NOT NULL,
	[Institution] [nvarchar](max) NOT NULL,
	[TeachingExperience] [nvarchar](max) NOT NULL,
	[ProfilePictureUrl] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[UniversityId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Professors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 12/12/2023 1:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Birthdate] [datetime2](7) NOT NULL,
	[Country] [nvarchar](max) NOT NULL,
	[Faculty] [nvarchar](max) NOT NULL,
	[ClassOf] [nvarchar](max) NOT NULL,
	[Preferences] [nvarchar](max) NOT NULL,
	[ProfilePictureUrl] [nvarchar](max) NULL,
	[UniversityName] [nvarchar](max) NULL,
	[UniversityId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Universities]    Script Date: 12/12/2023 1:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Universities](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Location] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Website] [nvarchar](max) NOT NULL,
	[EducationalSystemInfo] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[EducationalProgramUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_Universities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Universities_UniversityId] FOREIGN KEY([UniversityId])
REFERENCES [dbo].[Universities] ([Id])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Universities_UniversityId]
GO
ALTER TABLE [dbo].[Professors]  WITH CHECK ADD  CONSTRAINT [FK_Professors_Universities_UniversityId] FOREIGN KEY([UniversityId])
REFERENCES [dbo].[Universities] ([Id])
GO
ALTER TABLE [dbo].[Professors] CHECK CONSTRAINT [FK_Professors_Universities_UniversityId]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Universities_UniversityId] FOREIGN KEY([UniversityId])
REFERENCES [dbo].[Universities] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Universities_UniversityId]
GO
