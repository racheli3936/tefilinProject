export type StoreStand = {
    Id: number,
    StandId: number,
    StoreId: number,
    ActivityStartDate: Date,
    ActivityEndDate: Date,
    AlonimCount: number,
    Notes: string,
    ActivityHoursStart: TimeRanges,
    ActivityHoursEnd: TimeRanges
}