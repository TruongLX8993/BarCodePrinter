<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet exclude-result-prefixes="msxsl js" version="1.0" xmlns="http://www.w3.org/1999/xhtml"
                xmlns:ds="http://www.w3.org/2000/09/xmldsig#" xmlns:js="urn:custom-javascript"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:template match="/">
        
        <div  xmlns="http://www.w3.org/1999/xhtml" id="container" style="text-align: left">
            <style>
                .patient span {
                font-weight: bold;
                }
                
                #patient-year {
                float: right;
                }
                
                .department {
                text-align: center;
                }
                
                #department-name {
                display: inline-block;
                }
                
                #time {
                text-align: center;
                display: block;
                }
                
                
                #barcode-content {
                text-align: center;
                display: block;
                font-weight: bold;
                }
                
                #footer {
                display: block;
                float: right;
                }
                
                span {
                margin-bottom: 0.1em;
                font-size: 0.8em;
                }
                
                img {
                width: 100%;
                object-fit: contain;
                }
            </style>
            <div class="patient">
                <span id="patient-name"><xsl:value-of select="//Patient//Name"/></span>
                <span id="patient-year"><xsl:value-of select="//Patient//Year"/> </span>
            </div>
            <div class="department">
                <span id="department-name"><xsl:value-of select="//Department/Name"/></span>
            </div>
            <span id="time"><xsl:value-of select="//Time"/></span>
            <img>
                <xsl:attribute name="src">
                    <xsl:value-of select="concat('data:image/gif;base64,',//QrCode/Img)"/>
                </xsl:attribute>
            </img>
            <span id="barcode-content"><xsl:value-of select="//QrCode/Content"/></span>
        </div>
    </xsl:template>
</xsl:stylesheet>