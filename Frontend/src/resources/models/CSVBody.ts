export interface CSVBody {
    id: number, 
    name: string, 
    fileAsBase64?: string, 
    creationDate?: Date,
    lastUpdate?: Date 
    delimiter: string,
    informationDecoded: string[],
}