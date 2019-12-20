/* 새 데이터베이스 */
USE [DB1]
GO

/* 학생 */
CREATE TABLE [STUDENT] (
	[NUMBER] [varchar](100) NOT NULL,  /* 학번 */
	[NAME] [varchar](100),  /* 이름 */
	[AGE] [varchar](100),  /* 나이 */
	[SEX] [varchar](100) /* 성별 */
)
GO

/* 학생 기본키 */
ALTER TABLE [STUDENT]
	ADD
		CONSTRAINT [PK_STUDENT]
		PRIMARY KEY NONCLUSTERED (
			[NUMBER] ASC
		)
GO

/* 성적 */
CREATE TABLE [SCORE] (
	[NUMBER] [varchar](100) NOT NULL,  /* 학번 */
	[KOREAN] [varchar](100),  /* 국어 */
	[ENGLISH] [varchar](100),  /* 영어 */
	[MATH] [varchar](100),  /* 수학 */
	[SOCIAL] [varchar](100),  /* 사회 */
	[SCIENCE] [varchar](100) /* 과학 */
)
GO

/* 성적 기본키 */
ALTER TABLE [SCORE]
	ADD
		CONSTRAINT [PK_SCORE]
		PRIMARY KEY NONCLUSTERED (
			[NUMBER] ASC
		)
GO

/* 학생 -> 성적 */
ALTER TABLE [SCORE]
	ADD
		CONSTRAINT [FK_STUDENT_TO_SCORE]
		FOREIGN KEY (
			[NUMBER]
		)
		REFERENCES [STUDENT] (
			[NUMBER]
		)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
GO