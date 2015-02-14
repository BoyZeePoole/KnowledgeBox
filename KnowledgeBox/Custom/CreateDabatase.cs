using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KnowledgeBox.Custom
{
    public class CreateDatabase
    {
        SqlConnection conn = new SqlConnection();
        string username = "KnowledgeBoxUser";
        string password = "KB_User01!";
        string database = "KnowledgeBox";
        string server = "LJDEV_C38FJ12";
        string _message = string.Empty;
        //public void CreateDatabase()
        //{
        //    var ConnectionString = string.Format("data source={0};initial catalog={1};User ID={2};Password={3};", server, database, username, password);
        //    conn.ConnectionString = ConnectionString;
        //    conn.Open();
        //}
        public void ExecuteScript()
        {

            string sql = @"CREATE USER [KnowledgeBoxUser] FOR LOGIN [KnowledgeBoxUser] WITH DEFAULT_SCHEMA=[dbo]";

            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                cmd.ExecuteNonQuery();
                _message = "User Created...<br/>";
            }
            catch (SqlException ae)
            {
                _message = ae.Message.ToString() + "<br/>";                
            }
        }
        private void CreateCart()
        {
            string sql = @"CREATE TABLE [dbo].[Cart](
	                        [Id] [int] IDENTITY(1,1) NOT NULL,
	                        [Cart_Id] [uniqueidentifier] NOT NULL,
	                        [Cart_Date] [datetime] NOT NULL,
	                        [Item_Id] [int] NOT NULL,
                         CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
                        (
	                        [Id] ASC
                        )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                        ) ON [PRIMARY]";

            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                cmd.ExecuteNonQuery();
                _message += "Cart table Created...<br/>";
            }
            catch (SqlException ae)
            {
                _message += ae.Message.ToString() + "<br/>";                
            }
        }
        private void CreateContentType()
        {
            var sql = @"CREATE TABLE [dbo].[ContentType](
	                [ContentType_Id] [int] IDENTITY(1,1) NOT NULL,
	                [ContentType_Date] [datetime] NOT NULL,
	                [ContentType_Description] [varchar](150) NOT NULL,
	                [ContentType_Thumbnail] [varchar](50) NULL,
	                [CreatedBy] [int] NOT NULL,
                 CONSTRAINT [PK_ContentType] PRIMARY KEY CLUSTERED 
                (
	                [ContentType_Id] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                ) ON [PRIMARY]
                ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                cmd.ExecuteNonQuery();
                _message += "Cart Table Created<br/>";

                sql = @"insert into ContentType Values('Nov  3 2014  7:00PM','Adobe Flash Video','Thumbnail_Flash.jpg',1)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into ContentType Values('Nov  3 2014  7:00PM','Word Document','Thumbnail_Word.jpg',1)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into ContentType Values('Nov  3 2014  7:00PM','Image','icon_image_small.png',1)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into ContentType Values('Nov  3 2014  7:00PM','Application','Thumbnail_Excel.jpg',1)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into ContentType Values('Nov  3 2014  7:00PM','PDF File','Thumbnail_PDF.jpg',1)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into ContentType Values('Nov  3 2014  7:00PM','Video','Video-Icon.jpg',1)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into ContentType Values('Nov  3 2014  7:00PM','Flash swf','File-Adobe-Flash-SWF-01-icon.png',1)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                _message += "ContentType data added<br/>";
            }
            catch (SqlException ae)
            {
                _message += ae.Message.ToString() + "<br/>";
            }
        }

        private void CreatePhase()
        {
            var sql = @"CREATE TABLE [dbo].[Phase](
	                    [Phase_Id] [int] IDENTITY(1,1) NOT NULL,
	                    [Phase_Description] [varchar](150) NOT NULL,
	                    [Phase_Date] [datetime] NOT NULL,
	                    [CreatedBy] [int] NOT NULL,
                     CONSTRAINT [PK_Phase] PRIMARY KEY CLUSTERED 
                    (
	                    [Phase_Id] ASC
                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                    ) ON [PRIMARY]
                ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                cmd.ExecuteNonQuery();
                _message += "Phase Table Created<br/>";

                sql = @"insert into Phase (Phase_Date, Phase_Description, CreatedBy) Values('Nov  3 2014  7:19PM','Foundation Phase',1)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into Phase (Phase_Date, Phase_Description, CreatedBy) Values('Nov  3 2014  7:19PM','Intermediate Phase',1)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into Phase (Phase_Date, Phase_Description, CreatedBy) Values('Nov  3 2014  7:19PM','FET',1)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into Phase (Phase_Date, Phase_Description, CreatedBy) Values('Nov  3 2014  7:19PM','Senior Phase',1)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into Phase (Phase_Date, Phase_Description, CreatedBy) Values('Nov  3 2014  7:19PM','Teachers Tools',1)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into Phase (Phase_Date, Phase_Description, CreatedBy) Values('Nov  3 2014  7:19PM','Whats New',1)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into Phase (Phase_Date, Phase_Description, CreatedBy) Values('Nov  3 2014  7:19PM','Listen',1)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                _message += "Phase data added<br/>";
            }
            catch (SqlException ae)
            {
                _message += ae.Message.ToString() + "<br/>";
            }
        }

        private void CreateTarget()
        {
            var sql = @" 
                        CREATE TABLE [dbo].[Target](
	                        [Target_Id] [int] IDENTITY(1,1) NOT NULL,
	                        [Target_Description] [varchar](150) NOT NULL,
	                        [Target_Date] [datetime] NOT NULL,
	                        [CreatedBy] [int] NOT NULL,
                         CONSTRAINT [PK_Target] PRIMARY KEY CLUSTERED 
                        (
	                        [Target_Id] ASC
                        )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                        ) ON [PRIMARY]
                ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                cmd.ExecuteNonQuery();
                _message += "Target Table Created<br/>";

                sql = @"insert into Target (Target_Date, Target_Description, CreatedBy) Values('Nov  3 2014  7:25PM','Parents',1)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into Target (Target_Date, Target_Description, CreatedBy) Values('Nov  3 2014  7:25PM','Teachers',1)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into Target (Target_Date, Target_Description, CreatedBy) Values('Nov  3 2014  7:25PM','Learner',1)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                _message += "Target data added<br/>";
            }
            catch (SqlException ae)
            {
                _message += ae.Message.ToString() + "<br/>";
            }
        }
        
        private void CreateSubject()
        {
            var sql = @"CREATE TABLE [dbo].[Subject](
	                    [Subject_Id] [int] IDENTITY(1,1) NOT NULL,
	                    [Subject_Description] [varchar](150) NOT NULL,
	                    [Subject_Date] [datetime] NOT NULL,
	                    [Subject_Thumbnail] [varchar](150) NULL,
	                    [CreatedBy] [int] NOT NULL,
                     CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
                    (
	                    [Subject_Id] ASC
                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                    ) ON [PRIMARY] 
                ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                cmd.ExecuteNonQuery();
                _message += "Subject Table Created<br/>";

                sql = @"insert into Subject (Subject_Date, Subject_Description, CreatedBy, Subject_Thumbnail) Values('Nov  3 2014  7:29PM','Mathematics',1,'MathenaticsRes.jpg)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into Subject (Subject_Date, Subject_Description, CreatedBy, Subject_Thumbnail) Values('Nov  3 2014  7:29PM','Science',1,'NaturalSciencesRes.jpg)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into Subject (Subject_Date, Subject_Description, CreatedBy, Subject_Thumbnail) Values('Nov  3 2014  7:29PM','Literacy',1,'Phase_Literacy_Thumbnail.jpg)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into Subject (Subject_Date, Subject_Description, CreatedBy, Subject_Thumbnail) Values('Nov  3 2014  7:29PM','Life Skills',1,'Subject_LifeSkills.jpg)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into Subject (Subject_Date, Subject_Description, CreatedBy, Subject_Thumbnail) Values('Nov  3 2014  7:29PM','Numeracy',1,'Phase_Numeracy_Thumbnail.jpg)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into Subject (Subject_Date, Subject_Description, CreatedBy, Subject_Thumbnail) Values('Nov  3 2014  7:29PM','Languages',1,'LanguageRes.jpg)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into Subject (Subject_Date, Subject_Description, CreatedBy, Subject_Thumbnail) Values('Nov  3 2014  7:29PM','Economic and Management Sciences',1,'EconomicManagementRes.jpg)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into Subject (Subject_Date, Subject_Description, CreatedBy, Subject_Thumbnail) Values('Nov  3 2014  7:29PM','Technology',1,'TechnologyRes.jpg)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into Subject (Subject_Date, Subject_Description, CreatedBy, Subject_Thumbnail) Values('Nov  3 2014  7:29PM','Life Orientation',1,'LifeOrientationRes.jpg)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into Subject (Subject_Date, Subject_Description, CreatedBy, Subject_Thumbnail) Values('Nov  3 2014  7:29PM','Natural Sciences',1,'NaturalSciencesRes.jpg)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into Subject (Subject_Date, Subject_Description, CreatedBy, Subject_Thumbnail) Values('Nov  3 2014  7:29PM','Creative Arts',1,'CreativeArtsRes.jpg)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into Subject (Subject_Date, Subject_Description, CreatedBy, Subject_Thumbnail) Values('Nov  3 2014  7:29PM','Social Sciences',1,'SocialSciencesRes.jpg)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                _message += "Subject data added<br/>";
            }
            catch (SqlException ae)
            {
                _message += ae.Message.ToString() + "<br/>";
            }
        }
        private void CreateItem()
        {
            var sql = @"CREATE TABLE [dbo].[Item](
	                    [Item_Id] [int] IDENTITY(1,1) NOT NULL,
	                    [Item_Date] [datetime] NOT NULL,
	                    [Item_Name] [varchar](50) NOT NULL,
	                    [Item_Description] [varchar](max) NOT NULL,
	                    [Item_TagWords] [varchar](300) NULL,
	                    [Item_SystemFileName] [varchar](150) NULL,
	                    [Item_FilePath] [varchar](150) NOT NULL,
	                    [CreatedBy] [int] NULL,
	                    [ContentType_Id] [int] NOT NULL,
	                    [Phase_Id] [int] NOT NULL,
                     CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
                    (
	                    [Item_Id] ASC
                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
                ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                cmd.ExecuteNonQuery();
                _message += "Item Table Created<br/>";

                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','The Sleeper Awakes','The Sleeper Awakes (H.G.Wells)','ebook The Sleeper Awakes Science fiction','','FET/wellshg12161216312163-8.pdf',1,8,3)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','The Time Machine','The Time Machine (H.G.Wells)','The Time Machine H.G.Wells','','FET/wellshgetext92timem11.pdf',1,8,3)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','War of the Worlds','War of the Worlds (H.G.Wells)','War of the Worlds H.G.Wells','','FET/wellshgetext92warw12.pdf',1,8,3)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','The Art of War','The Art of War (Sun Tzu)','The Art of War Sun Tzu','','FET/tzusun132132.pdf',1,8,3)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','The Art of Public Speaking','The Art of Public Speaking (Dale Carnegie)','The Art of Public Speaking Dale Carnegie','','FET/carnegieda16311631716317-8.pdf',1,8,3)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Embarking the Essential Guide to Online Marketing','Embarking the Essential Guide to Online Marketing (Rob Stokes)','Essential Guide to Online Marketing Rob Stokes','','FET/Quirk_eMarketingTextbook.pdf',1,8,3)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Dracula','Dracula (Bram Stoker)','Dracula Bram Stoker horror','','FET/stokerbretext95dracu12.pdf',1,8,3)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','The Call Cthulhu','The Call Cthulhu (H.P.Lovecraft)','The Call Cthulhu H.P.Lovecraft horror','','FET/lovecrafthother06cthulhu.pdf',1,8,3)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Moby Dick','Moby Dick (Herman Melville)','Moby Dick Herman Melville fiction','','FET/melvilleetext01moby11.pdf',1,8,3)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Emma','Emma (Jane Austen)','Emma Jane Austen fiction','','FET/austenjaetext94emma11.pdf',1,8,3)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Lady Susan','Lady Susan (Jane Austen)','Lady Susan Jane Austen Fiction','','FET/austenjaetext97lsusn11.pdf',1,8,3)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Mansfield Park','Mansfield Park (Jane Austen)','Mansfield Park Jane Austen fiction','','FET/austenjaetext94mansf10.pdf',1,8,3)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Northanger Abbey','Northanger Abbey (Jane Austen)','Northanger Abbey Jane Austen fiction','','FET/austenjaetext94nabby11.pdf',1,8,3)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Persuasion','Persuasion (Jane Austen)','Persuasion Jane Austen','','FET/austenjaetext94persu11.pdf',1,8,3)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Pride and Predjudice','Pride and Predjudice (Jane Austen)','Pride and Predjudice Jane Austen','','FET/austenjaetext98pandp12.pdf',1,8,3)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Sense and Sensibility','Sense and Sensibility (Jane Austen)','Sense and Sensibility Jane Austen Fiction','','FET/austenjaetext94sense11.pdf',1,8,3)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Alices Adventures in Wonderland','Alices Adventures in Wonderland (Lewis Carrol)','Alices Adventures in Wonderland Lewis Carrol fantasy','','FET/carrollletext91alice30.pdf',1,8,3)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Through the Looking Glass','Through the Looking Glass (Lewis Carrol)','Through the Looking Glass Lewis Carrol','','FET/carrollletext91lglass19.pdf',1,8,3)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Adventures of Sherlock Holmes','Adventures of Sherlock Holmes (Arthur Conan-Doyle)','Adventures of Sherlock Holmes Arthur Conan-Doyle detective','','FET/doyleartetext99advsh12.pdf',1,8,3)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Study in Scarlet','Study in Scarlet (Arthur Conan-Doyle)','Study in Scarlet Arthur Conan-Doyle detective','','FET/doyleartetext95study10.pdf',1,8,3)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','His Last Bow','His Last Bow (Arthur Conan Doyle)','His Last Bow Arthur Conan Doyle','','FET/doyleartother07his_last_bow.pdf',1,8,3)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','The Hound of Baskervilles','The Hound of Baskervilles (Arthur Conan doyle)','The Hound of Baskervilles Arthur Conan doyle detective','','FET/doyleartetext02bskrv11a.pdf',1,8,3)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','The memoirs of Sherlock Holmes','The memoirs of Sherlock Holmes (Arthur Conan Doyle)','The memoirs of Sherlock Holmes Arthur Conan Doyle detective','','FET/doyleartetext97memho11.pdf',1,8,3)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','The Count of Monte Christo','The Count of Monte Christo (Alexandre Dumas)','The Count of Monte Christo Alexandre Dumas','','FET/dumasalpetext98crsto12.pdf',3,8,3)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Aqueous Base','Aqueous Base ','Aqueous Base chemistry','','Senior Phase/Aqueous bases_x264.mp4',3,9,4)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Chromatography ','Chromatography','Chromatography chemistry','','Senior Phase/Chromatography_x264.mp4',3,9,4)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Copper Oxide Reduction','Copper Oxide Reduction','Copper Oxide Reduction chemistry','','Senior Phase/Copper oxide reduction_x264.mp4',3,9,4)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Dissolving Sodium Chloride','Dissolving Sodium Chloride','Dissolving Sodium Chloride chemistry','','Senior Phase/Dissolving sodium chloride_x264.mp4',3,9,4)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Acid Base','Acid Base','Acid Base chemistry','','Senior Phase/atom.swf',3,10,4)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Ammonia','Ammonia','Ammonia chemistry ','','Senior Phase/Ammonia.swf',3,10,4)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Atmos Layers','Atmos Layers','Atmos Layers swf chemistry','','Senior Phase/atmoslayers[1].swf',3,10,4)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Atom','Atom','Atom Chemistry','','Senior Phase/atom.swf',3,10,4)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Boundaries','Boundaries','Boundaries Flash chemistry','','Senior Phase/ess05_int_boundaries.swf',3,10,4)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Butanol','Butanol','Butanol Chemistry','','Senior Phase/Butanol.swf',3,10,4)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Carbon Dioxide','Carbon Dioxide','Carbon Dioxide Chemistry Senior','','Senior Phase/Carbon dioxide.swf',3,10,4)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Chemical Bonds','Chemical Bonds','Chemical Bonds Chemistry','','Senior Phase/Chem bonds.swf',3,10,4)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Collision','Collision','Collision Chemistry','','Senior Phase/collision.swf',3,10,4)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Core','Core','Core Chemistry','','Senior Phase/core[1].swf',3,10,4)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Disolvesalt','Disolvesalt','Disolvesalt Chemistry','','FET/lsps07_int_dissolvesalt.swf',3,10,3)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Earth','Earth','Earth ','','FET/EARTH.swf',3,10,3)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = @"";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = @"insert into Item (Item_Date, Item_Name, Item_Description, Item_TagWords, Item_SystemFileName, Item_FilePath, CreatedBy, ContentType_Id, Phase_Id) Values('Nov  3 2014  7:42PM','Forces','Forces','Forces Chemistry','','FET/forces.swf',3,10,3)";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();


                _message += "Item data added<br/>";
            }
            catch (SqlException ae)
            {
                _message += ae.Message.ToString() + "<br/>";
            }
        }

        private void CreateItemSubject()
        {
            var sql = @" CREATE TABLE [dbo].[ItemSubject](
	                    [ItemSubject_Id] [int] IDENTITY(1,1) NOT NULL,
	                    [Item_Id] [int] NOT NULL,
	                    [Subject_Id] [int] NOT NULL,
                        CONSTRAINT [PK_ItemSubject] PRIMARY KEY CLUSTERED 
                    (
	                    [ItemSubject_Id] ASC
                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                    ) ON [PRIMARY]
                ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                cmd.ExecuteNonQuery();
                _message += "ItemSubject Table Created<br/>";

                sql = @"";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                _message += "ItemSubject data added<br/>";
            }
            catch (SqlException ae)
            {
                _message = ae.Message.ToString() + "<br/>";
            }
        }
    }
}

/*
            var sql = @" 
                ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                cmd.ExecuteNonQuery();
                _message += "Phase Table Created<br/>";

                sql = @"";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                _message += "Phase data added<br/>";
            }
            catch (SqlException ae)
            {
                _message = ae.Message.ToString() + "<br/>";
            }
*/