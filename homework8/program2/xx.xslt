<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:output method="xml" indent="yes"/>

  <xsl:template match="/ArrayOfOrder">
    <html>
      <head>
        <title>Orders</title>
      </head>
      <body>
        <ul>
          <xsl:for-each select="Order">
            <li>
              
              订单号： <xsl:value-of select="ordernum" />
            </li>
            <li>
              
              客户名称： <xsl:value-of select="customename" />
            </li>
            <li>
              
              订单细节：
            </li>
            <xsl:for-each select="detaillist/OrderDetails">
              <li>
               商品名称：<xsl:value-of select="goodsname" /> 商品数量：<xsl:value-of select="goodsnum" /> 商品价格：<xsl:value-of select="goodsprice" />
              </li>
            </xsl:for-each>
          </xsl:for-each>
        </ul>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
