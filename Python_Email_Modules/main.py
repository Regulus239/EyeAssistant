from fetchEmailData import fetchEmailData
from organizeEmailData import organizeEmailData
import email

emailDataList = fetchEmailData()
organizedDataList = organizeEmailData(emailDataList)
