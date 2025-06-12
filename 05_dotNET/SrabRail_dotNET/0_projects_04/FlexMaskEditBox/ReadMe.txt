
-- Instructions for using the FlexMaskEditControl control in a new project

1. Start Microsoft Visual Studio .NET.

2. Open the FlexMaskEdit.vbproj project.

3. On the Build menu, click Build Solution to build FlexMaskEdit.dll.

4. Close the project.

5. Create a new Windows application using Visual Basic .NET. Form1 is created by default.

6. On the Tools menu, click Customize Toolbox.

7. Select the .NET Framework Components tab.

8. Click the Browse button.

9. Navigate to the folder where FlexMaskEdit.dll was built (it should be the Bin folder located underneath the location where you unzipped the project).

10. Select FlexMaskEdit.dll and click Open. It will automatically add it to the selected components list and check the item for you.

11. Click OK to close the Customize Toolbox dialog box. Note that the FlexMaskEdit control now appears on your Toolbox.


<< Directions use of the FlexMaskEditBox application. >>
-----------------------------------------------------------------------------
Delete - delete char right from the cursor
Shift +	Delete - delete char left from the cursor
Ctrl  + Delete - delete all chars right from the cursor
					
BackSpace - delete position in front of the cursor + drags chars after the cursor 1 position
Shift + BackSpace - delete position in front of the cursor (don't drag)

Shift + Left Arrow or Right Arrow, select text, next Del to delete.

Select FieldType NumericField if:
-  working with decimals 
   mask for instance "#####d##" or "99d99" or "(##d##)  >????" or "##.## ##d##" 
   Flex Cursor goes automatic to the decimal point when pushed.
-  the (-) sign is valid by mask sign (9)


Mask signs (compatible with MS maskeditbox)
You are so free as your own ingenuity 
   (People with an artistic background has the highest score :))


(#) - (chr 48 - 57)

(9) - (chr 48 - 57) (-) minus sign

(?) - (chr 65 - 90) (chr 97 - 121)

(A)(C)  - (chr 65 - 90) (chr 97 - 121) (chr 48 - 57)

(a)(c)  - (chr 65 - 90) (chr 97 - 121) (chr 48 - 57) (chr 32 )

(&) - (chr 32 - 126) (chr 128 - 255)

(\)  Next char will be no mask char

(>) All chars next to the > sign will transformed in upper-case
    until the next mask char is an (<) or (\) or (|)

(}) Next 1 Char will transformed in upper-case
    
(<) All chars next to the < sign will transformed in lower-case
    until the next mask char is an (>) or (\) or (|)
    
(|) Stops next chars from Upper or Lower casing

({) Next 1 Char will transformed in lower-case

(d)(D)  Decimal Point (#####d99) = 12345.67 or 12345,67  
	(depending on country settings)

(g)(G)  Group Seperator (##g###g###d##) = 12.345.678,90 or 12,345,678.90
    (depending on country settings)
  
(s)(S) DateSeperator (##s##s####) = 12-12-2000 or 12/12/2000
    (depending on country settings)

    
a few mask examples (also combinations are possible)


													MaskCharIncl
input					mask						ON							OFF
"12-12-90"			"##S##S1\9##"			"12-12-1990"			"12-12-90"
"233,20"				"#####d##"				"223,20"					"223,40"
"123.456,43"      "###g###d##"			"123.456,43"			"123456,43"
"abcdefgh"			"(???)-(???)-(??)"	"(abc)-(def)-(gh)"	"abcdefgh"
