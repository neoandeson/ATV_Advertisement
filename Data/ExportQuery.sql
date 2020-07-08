SELECT *
FROM ProductScheduleShow
WHERE ShowDate = '06/09/2019'

SELECT ShowDate as 'Ngày Chiếu', TimeSlot as 'Khung giờ', TimeSlotLength as 'Giờ', TimeSlotLength as 'TL', TimeSlotLength as 'Tổng thời lượng'
FROM ProductScheduleShow
WHERE ShowDate = '06/09/2019'