import { TableCell } from "@mui/material";

const TableCellInput = ({text}:{text: string}) => {
    return (
        <>
            <TableCell align="right" sx={{ fontWeight: 'bold' }}>
                {text}
            </TableCell>
        </>
    )

}
export default TableCellInput;