export class FgvInputFile_File {
    identificador: string;
    size: number;
    name: string;
    lastModified: number;
    lastModifiedDate: Date;
    type: string;
    extension: string;
    readerProgress: number;
    fileBytes: any;
    srcImage: string;
    bytesInBrowser: boolean;

    sizeMb(): number {
        return this.size / 1024 / 1024;
    }
}
